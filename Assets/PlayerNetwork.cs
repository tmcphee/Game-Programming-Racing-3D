using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour{

	// Use this for initialization
	void Start () {
		GameObject player = this.gameObject;
		CmdSetPrefab(player, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	public void CmdSetPrefab(GameObject player, int value)
	{
		Debug.Log("change");
		var conn = player.GetComponent<NetworkIdentity>().connectionToClient;
		GameObject playerPrefab = NetworkManager.singleton.spawnPrefabs[value];
		NetworkServer.ReplacePlayerForConnection(conn, playerPrefab, 0);
	}
}
