using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SavedPoundsInfo : MonoBehaviour {

	int savedMoney;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		savedMoney = PlayerPrefs.GetInt ("Money");
		
		if (savedMoney >= 0) {
			GetComponent<Text> ().text = savedMoney.ToString ();
		} else
			GetComponent<Text> ().text = "No Save";
	}
}
