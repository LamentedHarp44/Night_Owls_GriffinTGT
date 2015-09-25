using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentPoundsInfo : MonoBehaviour {
	int value;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().loot;

		GetComponent<Text> ().text = value.ToString();

	}
}
