using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class movement : NetworkBehaviour{ //Add Networking

	public float movementSpeed = 20f;
	private float turnSpeed = 40;
	private Vector3 carRot = new Vector3(0.0f, 74, 0.0f);
	private Vector3 buggyRot = new Vector3(0.0f, 0f, 0.0f);
	Rigidbody rb;
	private Vector3 forward;
	bool isgamestarted = false;
	private bool[] checkpoints = new bool[4];
	public int implayer = 2;
	public static int winner = 0;

	void Start () {
		if (!isLocalPlayer) {
			this.transform.Find("Main Camera").gameObject.SetActive(false);
			return; 
		} //Add Networking


		rb = this.GetComponent<Rigidbody>();
		Debug.Log(Physics.gravity.y);
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
			//LoadingScreen(1);
			//return;
		}
		if (isServer && NetworkManager.singleton.numPlayers == 2 && isgamestarted == false)
		{
			GameObject g = GameObject.Find("SUV_prefab(Clone)");
			if (g) { g.transform.Rotate(carRot);}

			g = GameObject.Find("Wagon(Clone)");
			if (g) { g.transform.Rotate(buggyRot);}

			LoadingScreen(0);
			isgamestarted = true;
		}



		if (Input.GetKey (KeyCode.W) && (winner == 0)) {
			forward = this.transform.forward * movementSpeed;
			forward.y = rb.velocity.y;
			rb.AddForce (forward, ForceMode.Acceleration);
		} 
		else if (Input.GetKey (KeyCode.S) && (winner == 0)) {
			forward = this.transform.forward * -movementSpeed;
			forward.y = rb.velocity.y;

			rb.AddForce (forward, ForceMode.Acceleration);
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
