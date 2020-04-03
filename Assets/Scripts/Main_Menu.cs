using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
	public GameObject ParentObject;
	public GameObject camera;
	public Vector3 rotation;
	//Have Only Main Menu Object Enabled
	//Disable All other menus in unity

	void Start()
	{
		ParentObject = GameObject.Find("Canvas");
		camera = GameObject.Find("Camera");
		rotation = new Vector3(0.0f, 0.015f, 0.000f);
	}

	public void quitGame()
	{
		Debug.Log("Quitting Now");
		Application.Quit();
	}

	void Update()
	{
		//camera.transform.rotation = camera.transform.rotation * Quaternion.Euler(rotation);
		camera.transform.Rotate(rotation, Space.World);
	}



	/*****************************************************************************************************/
	//Vehicle Selection
	//----------------------------------------------------------------------------------------------------
	//To add vehicles -> Under Network Manager [Main Menu] then Registered Spawnable Prefabs -> Add Object
	//Object must have a Network Idnetity Component
	/*****************************************************************************************************/
	public void Option1()
	{
		NetworkManager.singleton.GetComponent<Networkmanager>().playerindex = 0;
		MultiplayerSetup();
	}
	public void Option2()
	{
		NetworkManager.singleton.GetComponent<Networkmanager>().playerindex = 1;
		MultiplayerSetup();
	}
	public void Option3()
	{
		NetworkManager.singleton.GetComponent<Networkmanager>().playerindex = 2;
		MultiplayerSetup();
	}
	public void Option4()
	{
		NetworkManager.singleton.GetComponent<Networkmanager>().playerindex = 3;
		MultiplayerSetup();
	}

	/*****************************************************************************************************/



	/*****************************************************************************************************/
	//Menu Switcher
	//----------------------------------------------------------------------------------------------------
	//Switch Between Menus
	/*****************************************************************************************************/

	public void SelectVehicle()
	{
		ParentObject.transform.Find("Main Menu").gameObject.SetActive(false);//Set Main Menu to disabled
		ParentObject.transform.Find("VehicleSelection").gameObject.SetActive(true);//Set VehicleSelection to Enabled
	}

	public void MultiplayerSetup()
	{
		ParentObject.transform.Find("VehicleSelection").gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.Find("MultiplayerMenu").gameObject.SetActive(true);//Set MultiplayerMenu to Enabled
	}

	public void playGame()
	{
		ParentObject.transform.Find("Main Menu").gameObject.SetActive(false);//Set Main Menu to disabled
		ParentObject.transform.Find("VehicleSelection").gameObject.SetActive(true);//Set VehicleSelection to Enabled
	}

	public void HostGame()
	{
		ParentObject.transform.Find("MultiplayerMenu").gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.Find("HostGameMenu").gameObject.SetActive(true);//Set HostGameMenu to Enabled
	}

	public void JoinGame()
	{
		ParentObject.transform.Find("MultiplayerMenu").gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.Find("JoinGameMenu").gameObject.SetActive(true);//Set JoinGameMenu to Enabled
	}

	public void BackToMultiplayerMenu()
	{
		ParentObject.transform.Find("MultiplayerMenu").gameObject.SetActive(true);//Set MultiplayerMenu to Enabled
		ParentObject.transform.Find("HostGameMenu").gameObject.SetActive(false);//Set HostGameMenu to Enabled
		ParentObject.transform.Find("JoinGameMenu").gameObject.SetActive(false);//Set JoinGameMenu to Enabled
	}

	public void BackToMainMenu()
	{
		ParentObject.transform.Find("Main Menu").gameObject.SetActive(true);//Set Main Menu to Enabled
		ParentObject.transform.Find("Options Menu").gameObject.SetActive(false);//Set Options to disabled
		ParentObject.transform.Find("VehicleSelection").gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.Find("MultiplayerMenu").gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.Find("HostGameMenu").gameObject.SetActive(false);//Set HostGameMenu to disabled
		ParentObject.transform.Find("JoinGameMenu").gameObject.SetActive(false);//Set JoinGameMenu to disabled
	}
	/*****************************************************************************************************/

}