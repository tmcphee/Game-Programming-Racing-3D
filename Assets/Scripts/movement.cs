using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class movement : MonoBehaviour {
public class movement : NetworkBehaviour{ //Add Networking

	public float movementSpeed = 20f;
	public float clockwise;
	Rigidbody rb;
	private Vector3 forward;
	private float rotation = 0;
	private int maxRotation = 60;
	private float forw = 0;
	private float left = 0;

	void Start () {
		if (!isLocalPlayer) {
			this.transform.Find("Main Camera").gameObject.SetActive(false);
			return; 
		} //Add Networking

		rb = this.GetComponent<Rigidbody>();
		Debug.Log(Physics.gravity.y);
	}

	void Update () {
		if (!isLocalPlayer) { return;  } //Add Networking

		forward = this.transform.forward * movementSpeed;
		forward.y = rb.velocity.y;

		if (Input.GetKey (KeyCode.W)) {
			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -forward;
			forward.y = -forward.y;

			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
		} 
		if(Input.GetKey(KeyCode.A))
			left = -1;
		else if(Input.GetKey(KeyCode.D))
			left = 1;
		transform.Rotate(0, left * forw, 0);
		}
	}
}
