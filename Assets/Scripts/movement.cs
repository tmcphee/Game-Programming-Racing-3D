using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : MonoBehaviour {
//public class movement : NetworkBehaviour{ //Add Networking

	public float movementSpeed = 20f;
	public float clockwise;
	Rigidbody rb;
	private Vector3 forward;
	private float rotation = 0;
	private int maxRotation = 60;

	void Start () {
		//if (isLocalPlayer) { return; } //Add Networking

		rb = this.GetComponent<Rigidbody>();
		Debug.Log(Physics.gravity.y);
	}

	void Update () {
		//if (isLocalPlayer) { return;  } //Add Networking

		forward = this.transform.forward * movementSpeed;
		forward.y = rb.velocity.y;

		if (Input.GetKey (KeyCode.W)) {
			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
			if (rotation <= maxRotation && rotation >=-maxRotation){
				this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotation, this.transform.eulerAngles.z);
			}
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -forward;
			forward.y = -forward.y;

			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
			this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotation, this.transform.eulerAngles.z);
			
		} 
		if(Input.GetKey(KeyCode.A)) {
			//this.transform.Rotate(0, clockwise, 0);
			if (rotation < maxRotation){
				rotation += clockwise;
			}
		}
		else if(Input.GetKey(KeyCode.D)) {
			if (rotation > -maxRotation){
				rotation -= clockwise;
			}
		}
	}
}
