using UnityEngine;
using System.Collections;

public class LoadGameBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSave()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lives = PlayerPrefs.GetInt ("Lives");
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().loot = PlayerPrefs.GetInt ("Money");
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lastCompleted = (LVL_CMPLT)PlayerPrefs.GetInt ("Level");
	}
}
