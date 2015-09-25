using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseMenuScript : MonoBehaviour {

	// Use this for initialization
	Canvas canvas;
	Button[] buttons;
	GameObject pauseAlert; 


	void Start () {
		canvas = GetComponent<Canvas>();
		buttons = canvas.GetComponentsInChildren<Button>();
		pauseAlert=GameObject.FindWithTag ("pauseAlert");
		pauseAlert.GetComponent<Text> ().text = "";
		if (buttons != null) {
			buttons [0].onClick.AddListener (() => {
				OnPauseGame ();});
			buttons [1].onClick.AddListener (() => {
				OnResumeGame ();});
			buttons [2].onClick.AddListener (() => {
				ExitGame ();});
			buttons [3].onClick.AddListener (() => {
				ExitLevel ();});


		}

	}

	void OnPauseGame ()
	{
		PlayerController.gamePause = true;
		pauseAlert.GetComponent<Text> ().text = "Game Paused";

	}

	void OnResumeGame ()
	{
		PlayerController.gamePause = false;
		pauseAlert.GetComponent<Text> ().text = "";

	}
	// Update is called once per frame
	void ExitGame(){
		Application.LoadLevel ("Main Menu");

	
	}

	void ExitLevel(){
		Application.LoadLevel ("level7"); 

	}


}