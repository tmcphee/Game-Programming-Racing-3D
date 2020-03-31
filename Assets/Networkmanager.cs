using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Networkmanager : NetworkManager {

	GameObject PlayerObject;

	// Use this for initialization
	int maxplayers = 1;
	int currentplayers = 0;

	/*public void StartGame(){
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}*/

	public void StartupHost(){
		SetPort();
		NetworkManager.singleton.maxConnections = 1;
		
		NetworkManager.singleton.StartHost();
		NetworkManager.singleton.playerPrefab = NetworkManager.singleton.spawnPrefabs[0];
		currentplayers++;
		Debug.Log("currentplayers: " + currentplayers);
	}

	public void JoinGame(){
		if(Network.connections.Length < maxplayers) {
			SetIPAddress();
			SetPort();
			NetworkManager.singleton.StartClient();
			currentplayers++;
			Debug.Log("currentplayers: " + currentplayers);
		}
	}

	public void SetPort(){
		string Port = GameObject.Find("PortFeild").transform.Find("Text").GetComponent<Text>().text;
		Debug.Log("PORT SET: " + Port);
		NetworkManager.singleton.networkPort = int.Parse(Port);
	}

	public void SetIPAddress(){
		string IPAddress = GameObject.Find("IPAddressFeild").transform.Find("Text").GetComponent<Text>().text;
		Debug.Log("IP SET: " + IPAddress);
		NetworkManager.singleton.networkAddress = IPAddress;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
