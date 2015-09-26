﻿using UnityEngine;
using System.Collections;

public class SaveButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveGame()
	{
		PlayerController temp = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();

		PlayerPrefs.SetInt ("Level", (int)temp.GetCompletedLevel ());
		PlayerPrefs.SetInt ("Money", temp.loot);
		PlayerPrefs.SetInt ("Lives", temp.lives);

		PlayerPrefs.Save ();
	}
}