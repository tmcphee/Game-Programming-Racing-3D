using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class VolumeScript : MonoBehaviour {
	public AudioMixer mixer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeVolume(float volume){
		mixer.SetFloat ("MusicVol", Mathf.Log10(volume) * 20);
	}
}
