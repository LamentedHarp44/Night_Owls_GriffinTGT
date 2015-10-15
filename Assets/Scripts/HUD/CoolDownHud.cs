using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoolDownHud : MonoBehaviour {
	public GameObject player;
	//variables for cooldown power timer
	//float coolDownTimer;
	//float cstartTimer;
	//int countDown=30;
	float targetTime;
	public GameObject coolText;
	//float cooldown;
	float duration;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		//coolText=GameObject.FindWithTag ("Cooldown");
		//coolDownTimer = 0.0f;
		//cstartTimer = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		/*if (targetTime > 0) {

			
			if(player.GetComponent<Invisiblilityscript>().cooldown>targetTime)
			//if (coolDownTimer > targetTime)
			{
				targetTime =0.0f;
				//coolDownTimer = 0.0f;
				player.GetComponent<Invisiblilityscript>().cooldown=0.0f;
				cstartTimer = 0.0f;
				coolText.GetComponent<Text> ().text = " ";
				player.GetComponent<PlayerController> ().cooled = false;
			}
			else
			{
			//coolDownTimer = Time.realtimeSinceStartup;
			player.GetComponent<Invisiblilityscript>().cooldown=Time.realtimeSinceStartup;
			float i=player.GetComponent<Invisiblilityscript>().cooldown- cstartTimer;
			//float i = coolDownTimer - cstartTimer;
				coolText.GetComponent<Text> ().text = ((int)(countDown - i) +1).ToString();
			}
		}*/
		coolDown ();
		//coolText.GetComponent<Text> ().text = "Cool Down: "+((int)cooldown).ToString()+"   Duration: "+ ((int)duration).ToString();

	}

	public void coolDown(){
		//player.GetComponent<Invisiblilityscript>().cooldown=Time.realtimeSinceStartup;
		//cstartTimer = Time.realtimeSinceStartup;
		//targetTime = cstartTimer + countDown;
		//player.GetComponent<Invisiblilityscript>().cooldown;
		//cooldown=player.GetComponent<Invisiblilityscript>().cooldown;
		duration=player.GetComponent<Invisiblilityscript>().duration;
	}
}
