﻿using UnityEngine;
using System.Collections;

public class GameMusicScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetMusicVolume(float volume)
	{
		GetComponent<AudioSource> ().volume = volume;
	}

}