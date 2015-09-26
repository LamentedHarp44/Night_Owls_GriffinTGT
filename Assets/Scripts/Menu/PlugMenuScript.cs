using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlugMenuScript : MonoBehaviour {


	// Use this for initialization
	Canvas canvas;
	Button[] buttons;
	GameObject Alert; 
	public GameObject player;
	void Start () {
		canvas = GetComponent<Canvas>();
		player=GameObject.FindWithTag ("Player");
		buttons = canvas.GetComponentsInChildren<Button>();
		Alert=GameObject.FindWithTag ("PlugAbility");
		Alert.GetComponent<Text> ().text = "";

		if (buttons != null) {
			buttons [0].onClick.AddListener (() => {
				CoolDownReduction ();});
			buttons [1].onClick.AddListener (() => {
				InvisibleDurationUP ();});
			buttons [2].onClick.AddListener (() => {
				TrulyInvisible ();});


			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CoolDownReduction(){
		if (player.GetComponent<Invisiblilityscript> ().fullCooldown > 5 && !player.GetComponent<Invisiblilityscript> ().IsOnCoolDown()) {
			player.GetComponent<Invisiblilityscript> ().fullCooldown -= 5.0f;
			player.GetComponent<Invisiblilityscript> ().cooldown=player.GetComponent<Invisiblilityscript> ().fullCooldown;
			Alert.GetComponent<Text> ().text = "time for cooldown has been reduced!";
		}
	}

	void InvisibleDurationUP(){
		player.GetComponent<Invisiblilityscript> ().fullDuration += 1.0f;
		player.GetComponent<Invisiblilityscript> ().duration = player.GetComponent<Invisiblilityscript> ().fullDuration;
		Alert.GetComponent<Text> ().text = "Invisibled duration become longer!";

	}

	void TrulyInvisible(){

		player.GetComponent<Invisiblilityscript> ().SetExposure (0);
		Alert.GetComponent<Text> ().text = "You are truly invisible now!!";

	}
}
