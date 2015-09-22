using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoolDownHud : MonoBehaviour {
	public GameObject player;
	//variables for cooldown power timer
	float coolDownTimer;
	float cstartTimer;
	int countDown=3;
	float targetTime;
	public GameObject coolText;

	// Use this for initialization
	void Start () {
		coolDownTimer = 0.0f;
		cstartTimer = 0.0f;
		player = GameObject.FindWithTag ("Player");
		coolText=GameObject.FindWithTag ("Cooldown");
	}
	
	// Update is called once per frame
	void Update () {
		if (targetTime > 0) {

			if (coolDownTimer > targetTime)
			{
				targetTime =0.0f;
				coolDownTimer = 0.0f;
				cstartTimer = 0.0f;
				coolText.GetComponent<Text> ().text = " ";
				player.GetComponent<PlayerController> ().cooled = false;
			}
			else
			{
			coolDownTimer = Time.realtimeSinceStartup;
			
			float i = coolDownTimer - cstartTimer;
				coolText.GetComponent<Text> ().text = ((int)(countDown - i) +1).ToString();
			}
		}
	}

	public void coolDown(){
		coolDownTimer = Time.realtimeSinceStartup;
		cstartTimer = Time.realtimeSinceStartup;
		
		//while (coolDownTimer-cstartTimer<=countDown) 
		//coolDownTimer = Time.realtimeSinceStartup;
		targetTime = cstartTimer + countDown;
		
		
		//coolDownTimer = 0.0f;
		//cstartTimer = 0.0f;
		//coolText.GetComponent<Text> ().text = " ";
		//player.GetComponent<PlayerController> ().cooled = false;
	}
}
