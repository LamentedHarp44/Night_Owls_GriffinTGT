using UnityEngine;
using System.Collections;

public class HelloCitizenScript : MonoBehaviour {
	bool played;
	// Use this for initialization
	void Start () {
		played = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (played == false && col.CompareTag("Player")) {
			GetComponentInChildren<AudioSource> ().Play ();

			played = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		played = false;
	}
}
