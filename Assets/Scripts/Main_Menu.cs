using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour {
	public GameObject ParentObject;

	void Start(){
		ParentObject = GameObject.Find("Canvas");
		//ParentObject = this.gameObject.transform.parent.gameObject;

		ParentObject.transform.GetChild(0).gameObject.SetActive(true);//Set Main Menu to disabled
		ParentObject.transform.GetChild(1).gameObject.SetActive(false);//Set Options to disabled
		ParentObject.transform.GetChild(2).gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set HostGameMenu to disabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(false);//Set JoinGameMenu to disabled
	}

	public void playGame(){
		ParentObject.transform.GetChild(0).gameObject.SetActive(false);//Set Main Menu to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(true);//Set MultiplayerSetup to Enabled
		//SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}

	public void HostGame(){
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(true);//Set HostGameMenu to Enabled
	}
	public void JoinGame(){
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(true);//Set JoinGameMenu to Enabled
	}

	public void BackToMultiplayerMenu()
	{
		ParentObject.transform.GetChild(3).gameObject.SetActive(true);//Set MultiplayerMenu to Enabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set HostGameMenu to Enabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(false);//Set JoinGameMenu to Enabled
	}

	public void BackToMainMenu()
	{
		ParentObject.transform.GetChild(0).gameObject.SetActive(true);//Set Main Menu to Enabled
		ParentObject.transform.GetChild(1).gameObject.SetActive(false);//Set Options to disabled
		ParentObject.transform.GetChild(2).gameObject.SetActive(false);//Set VehicleSelection to disabled
		ParentObject.transform.GetChild(3).gameObject.SetActive(false);//Set MultiplayerMenu to disabled
		ParentObject.transform.GetChild(4).gameObject.SetActive(false);//Set HostGameMenu to disabled
		ParentObject.transform.GetChild(5).gameObject.SetActive(false);//Set JoinGameMenu to disabled
	}

	public void quitGame(){
		Debug.Log ("Quitting Now");
		Application.Quit();
	}

}
