using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Audio;

public class movement : NetworkBehaviour{ //Add Networking

	public float movementSpeed = 20f;
	private float turnSpeed = 40;
	Rigidbody rb;
	private Vector3 forward;
	bool isgamestarted = false;
	private bool[] checkpoints = new bool[4];
	private int implayer = 2;
	public static int winner = 0;
	private AudioSource m_MyAudioSource;
	public AudioClip movingSound;
	public AudioClip idleSound;
	public AudioMixerGroup mixer;

	void Start () {
		if (!isLocalPlayer) {
			this.transform.Find("Main Camera").gameObject.SetActive(false);
			return; 
		} //Add Networking

		m_MyAudioSource = gameObject.AddComponent<AudioSource>();
		m_MyAudioSource.loop = true;
		m_MyAudioSource.clip = idleSound;
		m_MyAudioSource.outputAudioMixerGroup = mixer;
		m_MyAudioSource.Play();

		rb = this.GetComponent<Rigidbody>();
		Debug.Log(Physics.gravity.y);
		if (isServer)
		{
			this.transform.position = GameObject.Find("SpawnLocationPlayer1").gameObject.transform.position;
			//this.transform.rotation = GameObject.Find("SpawnLocationPlayer1").gameObject.transform.rotation;
		}
		else
		{
			this.transform.position = GameObject.Find("SpawnLocationPlayer2").gameObject.transform.position;
			//this.transform.rotation = GameObject.Find("SpawnLocationPlayer2").gameObject.transform.rotation;
		}

	}

	public void LoadingScreen(int value)
	{
		if (value == 1)
		{
			this.transform.Find("Main Camera").transform.Find("Canvas").gameObject.SetActive(true);
		}
		else
		{
			this.transform.Find("Main Camera").transform.Find("Canvas").gameObject.SetActive(false);
		}
	}

	void Update () {
		if (checkWin()){
			winner = implayer;
		}

		if (winner != 0){
			finishGame ();
		}

		if (!isLocalPlayer) { return;  } //Add Networking

		if (Input.GetKey(KeyCode.Escape))
		{
			if (isServer)
			{
				NetworkManager.singleton.StopHost();
			}
			else
			{
				//Request Server to take down host. Does this since cant race if player2 leaves.
				CmdStopGame();
			}
		}

		//Game not ready to start
		if (isServer && NetworkManager.singleton.numPlayers != 2)
		{
			implayer = 1;
			LoadingScreen(1);
			return;
		}
		if (isServer && NetworkManager.singleton.numPlayers == 2 && isgamestarted == false)
		{
			LoadingScreen(0);
			isgamestarted = true;
		}



		if (Input.GetKey (KeyCode.W) && (winner == 0)) {
			forward = this.transform.forward * movementSpeed;
			forward.y = rb.velocity.y;
			rb.AddForce (forward, ForceMode.Acceleration);
			if (m_MyAudioSource.clip == idleSound) {
				m_MyAudioSource.Stop ();
				m_MyAudioSource.clip = movingSound;
				m_MyAudioSource.Play ();
			}
		}
		else if (Input.GetKey (KeyCode.S) && (winner == 0)) {
			forward = this.transform.forward * -movementSpeed;
			forward.y = rb.velocity.y;
			rb.AddForce (forward, ForceMode.Acceleration);
		} else {
			if (m_MyAudioSource.clip == movingSound) {
				m_MyAudioSource.Stop ();
				m_MyAudioSource.clip = idleSound;
				m_MyAudioSource.Play ();
			}
		}

		if ( Input.GetKey (KeyCode.A) && ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) )
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		else if ( Input.GetKey (KeyCode.D)  && ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) )
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);

	}

	[Command]
	public void CmdStopGame()
	{
		NetworkManager.singleton.StopHost();
	}

	private void finishGame(){
		Text change = this.transform.Find ("Main Camera").transform.Find ("Canvas").transform.Find ("Player_notification").transform.Find ("text").GetComponent<Text>();
		change.text = "Player " + winner + "\nWins";
		LoadingScreen(1);

	}

	public void triggerCheckpoint(int id){
		if (id == 4) {
			if (checkpoints[0] && checkpoints[1] && checkpoints[2]) {
				checkpoints[3] = true;
			}
		} else {
			checkpoints[id - 1] = true;
		}

		Debug.Log("1: " + checkpoints[0] + "2: " + checkpoints[1] + "3: " + checkpoints[2]+ "Finish: " +  checkpoints[3]);
	}

	public bool checkWin(){
		return checkpoints[3];
	}
}
