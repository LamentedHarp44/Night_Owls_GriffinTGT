using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentLivesInfo : MonoBehaviour {

	int numLives;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {		
		numLives = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lives;

		GetComponent<Text> ().text = numLives.ToString ();
	}
}
