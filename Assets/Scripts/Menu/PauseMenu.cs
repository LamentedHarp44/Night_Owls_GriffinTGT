using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public bool gPause = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
			if (gPause)
				ResumeGame ();
			else
				PauseGame ();
		}
	}

	void PauseGame()
	{
		gPause = true;
		AudioSource[] aSs = GameObject.FindObjectsOfType<AudioSource> ();
		for (int i =0; i < aSs.Length; ++i) {
			aSs[i].enabled = false;
		}

		Rigidbody2D[] rBs = GameObject.FindObjectsOfType<Rigidbody2D> ();
		for (int i = 0; i < rBs.Length; ++i){
			rBs[i].Sleep();
		}

		Image[] iMs = GetComponentsInChildren<Image>();
		for (int i = 0; i < iMs.Length; ++i) {
			iMs[i].enabled = true;
		}
		
		Text[] tXs = GetComponentsInChildren<Text> ();
		for (int i = 0; i < tXs.Length; ++i) {
			tXs [i].enabled = true;
		}
		
		Button[] bTs = GetComponentsInChildren<Button> ();
		for (int i = 0; i < bTs.Length; ++i) {
			bTs [i].enabled = true;
		}
	}

	public void ResumeGame()
	{
		gPause = false;
		AudioSource[] aSs = GameObject.FindObjectsOfType<AudioSource> ();
		for (int i =0; i < aSs.Length; ++i) {
			aSs[i].enabled = true;
		}

		Rigidbody2D[] rBs = GameObject.FindObjectsOfType<Rigidbody2D> ();
		for (int i = 0; i < rBs.Length; ++i){
			rBs[i].WakeUp();
		}

		Image[] iMs = GetComponentsInChildren<Image>();
		for (int i = 0; i < iMs.Length; ++i) {
			iMs[i].enabled = false;
		}

		Text[] tXs = GetComponentsInChildren<Text> ();
		for (int i = 0; i < tXs.Length; ++i) {
			tXs [i].enabled = false;
		}

		Button[] bTs = GetComponentsInChildren<Button> ();
		for (int i = 0; i < bTs.Length; ++i) {
			bTs [i].enabled = false;
		}
	}
}
