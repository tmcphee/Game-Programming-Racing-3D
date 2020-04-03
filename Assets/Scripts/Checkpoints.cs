using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
	public int Checkpoint = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		movement move = other.gameObject.GetComponentInChildren<movement>();
		if(move != null){
			move.triggerCheckpoint(Checkpoint);
		}
		Debug.Log(other.gameObject);
	}
}
