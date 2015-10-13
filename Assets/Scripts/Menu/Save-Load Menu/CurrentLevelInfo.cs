using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentLevelInfo : MonoBehaviour {

	int currentLevel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		currentLevel = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetCompletedLevel();

		if (currentLevel == 10) {
			GetComponent<Text>().text = "None";
		}
		else
			GetComponent<Text> ().text = currentLevel.ToString();
	}
}
