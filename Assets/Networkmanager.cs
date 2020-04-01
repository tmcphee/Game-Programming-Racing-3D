using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Networkmanager : NetworkManager {

	GameObject PlayerObject;

	// Use this for initialization
	int maxplayers = 1;
	int currentplayers = 0;

	public class NetMeg : MessageBase{
		public int value;
	}

	/*public void StartGame(){
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}*/
	public void setPlayerPrefab(int index){
		PlayerObject = NetworkManager.singleton.spawnPrefabs[index];
	}

	public void StartupHost(){
		SetPort();
		NetworkManager.singleton.StartHost();
	}

	public void JoinGame(){
		SetIPAddress();
		SetPort();
		NetworkManager.singleton.StartClient();
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


	/*public override void OnClientConnect(NetworkConnection conn){
		IntegerMessage msg = new IntegerMessage(0);
		ClientScene.AddPlayer(conn, 1, msg);
	}*/
	public void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader){
		NetMeg msg = extraMessageReader.ReadMessage<NetMeg>();
		Debug.Log("CLIENT SENT: " + msg.value);
		GameObject playerPrefab = NetworkManager.singleton.spawnPrefabs[0];
		/*if (NetworkManager.singleton.)
		{
			
			playerPrefab = NetworkManager.singleton.spawnPrefabs[msg.value];
			
		}*/
		
		GameObject player = (GameObject)Instantiate(playerPrefab, NetworkManager.singleton.GetStartPosition().position, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*****************************************************************************************************/
	//Client Side
	/*****************************************************************************************************/
	
	public override void OnClientConnect(NetworkConnection conn){
		NetMeg msg = new NetMeg();
		msg.value = 1;
		ClientScene.AddPlayer(conn, 0, msg);
	}

	
}
