using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementNetworked : NetworkBehaviour {
	public float movementSpeed = 20f;
	public float clockwise;
	Rigidbody rb;
	private Vector3 forward;
	private float rotation = 0;
	private int maxRotation = 60;

	// Use this for initialization
	void Start () {
		if(isLocalPlayer){
			return;
		}
		rb = this.GetComponent<Rigidbody>();
		Debug.Log(Physics.gravity.y);
	}
	
	// Update is called once per frame
	void Update () {
        if(isLocalPlayer){
			return;
        }

		forward = this.transform.forward * movementSpeed;
		forward.y = rb.velocity.y;

		if (Input.GetKey(KeyCode.W))
		{
			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
			if (rotation <= maxRotation && rotation >= -maxRotation)
			{
				this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotation, this.transform.eulerAngles.z);
			}
		}
		else if (Input.GetKey(KeyCode.S))
		{
			forward = -forward;
			forward.y = -forward.y;

			//rb.velocity = forward;
			rb.AddForce(forward, ForceMode.Acceleration);
			this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotation, this.transform.eulerAngles.z);

		}
		if (Input.GetKey(KeyCode.A))
		{
			//this.transform.Rotate(0, clockwise, 0);
			if (rotation < maxRotation)
			{
				rotation += clockwise;
			}
		}
		else if (Input.GetKey(KeyCode.D))
		{
			if (rotation > -maxRotation)
			{
				rotation -= clockwise;
			}
		}
	}
}
