using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavedLevelInfo : MonoBehaviour {

	int savedLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		savedLevel = PlayerPrefs.GetInt ("Level");

		if (savedLevel >= 0 && savedLevel < 10) {
			GetComponent<Text> ().text = savedLevel.ToString ();
		} else
			GetComponent<Text> ().text = "None";
	}
}
