using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentLevelInfo : MonoBehaviour {

	string savedCurrentLevel;

	// Use this for initialization
	void Start () {
		savedCurrentLevel = PlayerPrefs.GetString ("CurrentLevel");

		GetComponent<Text> ().text = savedCurrentLevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
