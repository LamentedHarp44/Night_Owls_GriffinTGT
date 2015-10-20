using UnityEngine;
using System.Collections;

public class SoundEFXScript : MonoBehaviour {




	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("SFXVolume");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
