using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Networkmanager : NetworkManager {

	// Use this for initialization
	int maxplayers = 2;
	int currentplayers = 0;

	/*public void StartGame(){
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}*/

	public void StartupHost(){
		SetPort();
		NetworkManager.singleton.StartHost();
	}

	public void JoinGame(){
		if(currentplayers != maxplayers){
			SetIPAddress();
			SetPort();
			NetworkManager.singleton.StartClient();
			currentplayers++;
		}
	}

	/*public void Disconnect(){
		if (Network.isServer){
			NetworkManager.singleton.StopHost();
			NetworkManager.singleton.StopClient();
		}
		else{
			NetworkManager.singleton.StopClient();
		}
	}*/

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

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId){
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
