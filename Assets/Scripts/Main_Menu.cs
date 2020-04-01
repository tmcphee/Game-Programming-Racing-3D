using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine;

public class Main_Menu : MonoBehaviour {
	public GameObject ParentObject;

	//Have Only Main Menu Object Enabled
	//Disable All other menus in unity

	void Start(){
		ParentObject = GameObject.Find("Canvas");
	}

	public void quitGame(){
		Debug.Log("Quitting Now");
		Application.Quit();
	}



	/*****************************************************************************************************/
	//Vehicle Selection
	//----------------------------------------------------------------------------------------------------
	//To add vehicles -> Under Network Manager [Main Menu] then Registered Spawnable Prefabs -> Add Object
	//Object must have a Network Idnetity Component
	/*****************************************************************************************************/
	public void Option1(){
		//NetworkManager.singleton.playerPrefab = NetworkManager.singleton.spawnPrefabs[0];
		MultiplayerSetup();
	}
	public void Option2(){
		//NetworkManager.singleton.playerPrefab = NetworkManager.singleton.spawnPrefabs[1];
		MultiplayerSetup();
	}
	public void Option3(){
		//NetworkManager.singleton.playerPrefab = NetworkManager.singleton.spawnPrefabs[2];
		MultiplayerSetup();
	}
	public void Option4(){
		//NetworkManager.singleton.playerPrefab = NetworkManager.singleton.spawnPrefabs[3];
		MultiplayerSetup();
	}

	/*****************************************************************************************************/



	/*****************************************************************************************************/
	//Menu Switcher
	//----------------------------------------------------------------------------------------------------
	//Switch Between Menus
	//Values Set Baised on Order in Unity -- DONT MOVE
	/*****************************************************************************************************/

	public void SelectVehicle(){
		ParentObject.transform.GetChild(1).gameObject.SetActive(false);//Set Main Menu to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(true);//Set VehicleSelection to Enabled
	}

	public void MultiplayerSetup(){
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(true);//Set MultiplayerSetup to Enabled
	}

	public void playGame(){
		ParentObject.transform.GetChild(1).gameObject.SetActive(false);//Set Main Menu to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(true);//Set VehicleSelection to Enabled
	}

	public void HostGame(){
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(true);//Set HostGameMenu to Enabled
	}

	public void JoinGame(){
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(6).gameObject.SetActive(true);//Set JoinGameMenu to Enabled
	}

	public void BackToMultiplayerMenu()
	{
		ParentObject.transform.GetChild(4).gameObject.SetActive(true);//Set MultiplayerMenu to Enabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(false);//Set HostGameMenu to Enabled
		ParentObject.transform.GetChild(6).gameObject.SetActive(false);//Set JoinGameMenu to Enabled
	}

	public void BackToMainMenu()
	{
		ParentObject.transform.GetChild(1).gameObject.SetActive(true);//Set Main Menu to Enabled
		ParentObject.transform.GetChild(2).gameObject.SetActive(false);//Set Options to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(false);//Set HostGameMenu to disabled
		ParentObject.transform.GetChild(6).gameObject.SetActive(false);//Set JoinGameMenu to disabled
	}
	/*****************************************************************************************************/

}
