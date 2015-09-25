using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavedLivesInfo : MonoBehaviour {

	int savedLives;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		savedLives = PlayerPrefs.GetInt ("Lives");
		
		if (savedLives >= 0 && savedLives <= 10) {
			GetComponent<Text> ().text = savedLives.ToString ();
		} else
			GetComponent<Text> ().text = "No Save";
	}
}
