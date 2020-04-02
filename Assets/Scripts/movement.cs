using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public float movementSpeed = 20f;
	public float clockwise = -3.0f;
	public float counterClockwise = 3.0f;
	Rigidbody rb;

	void Start () {
		rb = this.GetComponent<Rigidbody>();
		rb.angularDrag = 50;
	}

	void Update () {
		if(Input.GetKey(KeyCode.W)) {
			rb.AddForce(this.transform.forward * movementSpeed);
		}
		else if(Input.GetKey(KeyCode.S)) {
			rb.AddForce(-this.transform.forward * movementSpeed);
		}
		if(Input.GetKey(KeyCode.A)) {
			this.transform.Rotate(0, clockwise, 0);
		}
		else if(Input.GetKey(KeyCode.D)) {
			this.transform.Rotate(0, counterClockwise, 0);
		}
	}
}
