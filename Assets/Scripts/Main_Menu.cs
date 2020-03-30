using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour {

	public void playGame(){
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}

	public void quitGame(){
		Debug.Log ("Quitting Now");
		Application.Quit();
	}

}
