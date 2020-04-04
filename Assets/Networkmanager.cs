using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Networkmanager : NetworkManager
{

	public int playerindex = 0;
	int MaxPlayers = 2;
	int CurrentPlayers = 0;
	short playerid = 0;
	short isclient = 0;


	public class NetMeg : MessageBase
	{
		public int value;
	}

	/*public void StartGame(){
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}*/
	/*public void setPlayerPrefab(int index){
		PlayerObject = NetworkManager.singleton.spawnPrefabs[index];
	}*/

	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
		CurrentPlayers++;
	}

	public void JoinGame()
	{
		SetIPAddress();
		SetPort();
		isclient = 1;
		Debug.Log("Joined");
		NetworkManager.singleton.StartClient();
	}

	public void SetPort()
	{
		string Port = GameObject.Find("PortFeild").transform.Find("Text").GetComponent<Text>().text;
		Debug.Log("PORT SET: " + Port);
		NetworkManager.singleton.networkPort = int.Parse(Port);
	}

	public void SetIPAddress()
	{
		string IPAddress = GameObject.Find("IPAddressFeild").transform.Find("Text").GetComponent<Text>().text;
		Debug.Log("IP SET: " + IPAddress);
		NetworkManager.singleton.networkAddress = IPAddress;
	}


	public override void OnClientConnect(NetworkConnection conn)
	{
		playerid++;
		IntegerMessage msg = new IntegerMessage(playerindex);
		ClientScene.AddPlayer(conn, isclient, msg);

	}
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
	{
		NetMeg msg = extraMessageReader.ReadMessage<NetMeg>();
		Debug.Log("CLIENT SENT: " + msg.value + " -- connections: " + Network.connections.Length);
		GameObject player = Instantiate(NetworkManager.singleton.spawnPrefabs[msg.value], NetworkManager.singleton.GetStartPosition().position, NetworkManager.singleton.GetStartPosition().rotation) as GameObject;
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	void Start()
	{
		base.maxConnections = 2;
	}

	// Update is called once per frame
	void Update()
	{

	}

	/*****************************************************************************************************/
	//Client Side
	/*****************************************************************************************************/



}
