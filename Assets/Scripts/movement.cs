using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour{ //Add Networking

	public float movementSpeed = 20f;
	private float turnSpeed = 40;
	Rigidbody rb;
	private Vector3 forward;
	bool isgamestarted = false;

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
			this.transform.Find("Main Camera").transform.Find("Canvas").gameObject.SetActive(false);
		}
		else
		{
			this.transform.Find("Main Camera").transform.Find("Canvas").gameObject.SetActive(false);
		}
	}

	void Update () {
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
			LoadingScreen(1);
			return;
		}
		if (isServer && NetworkManager.singleton.numPlayers == 2 && isgamestarted == false)
		{
			LoadingScreen(0);
			isgamestarted = true;
		}

		forward = this.transform.forward * movementSpeed;
		forward.y = rb.velocity.y;

		if (Input.GetKey (KeyCode.W)) {
			//rb.velocity = forward;
			rb.AddForce (forward, ForceMode.Acceleration);
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -forward;
			forward.y = -forward.y;

			//rb.velocity = forward;
			rb.AddForce (forward, ForceMode.Acceleration);
		}

		if (Input.GetKey (KeyCode.A) && (Input.GetKey (KeyCode.W)) || (Input.GetKey (KeyCode.S)))
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.D) && (Input.GetKey (KeyCode.W)) || (Input.GetKey (KeyCode.S)))
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
	}

	[Command]
	public void CmdStopGame()
	{
		NetworkManager.singleton.StopHost();
	}
}
