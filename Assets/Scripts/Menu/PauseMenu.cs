using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {
	public bool gPause = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (gPause)
				ResumeGame ();
			else
				PauseGame ();
		}
	}

	void PauseGame()
	{
		gPause = true;
		AudioSource[] gOs = GameObject.FindObjectsOfType<AudioSource> ();
		for (int i =0; i < gOs.Length; ++i) {
			gOs[i].enabled = false;
		}

		Rigidbody2D[] rBs = GameObject.FindObjectsOfType<Rigidbody2D> ();
		for (int i = 0; i < rBs.Length; ++i){
			rBs[i].Sleep();
		}
	}

	void ResumeGame()
	{
		gPause = false;
		AudioSource[] gOs = GameObject.FindObjectsOfType<AudioSource> ();
		for (int i =0; i < gOs.Length; ++i) {
			gOs[i].enabled = true;
		}

		Rigidbody2D[] rBs = GameObject.FindObjectsOfType<Rigidbody2D> ();
		for (int i = 0; i < rBs.Length; ++i){
			rBs[i].WakeUp();
		}
	}
}
