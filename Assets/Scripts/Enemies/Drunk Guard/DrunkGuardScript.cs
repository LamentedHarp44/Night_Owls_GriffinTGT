using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrunkGuardScript : MonoBehaviour {

	float sleepTimer, awakeTimer;
	public float attackTimer;
	public float detRange;
	public bool sighted;
	public bool asleep;
	GameObject player;

	//  true = left.  false = right.
	public bool face;
	public AudioClip gunShot;


	void Start()
	{
		asleep = true;
		sleepTimer = awakeTimer = 7.0f;
	}

	public void Update()
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (GameObject.FindGameObjectWithTag("Pause") != null && GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {
			GetComponent<Animator>().SetBool("awake", true);
			asleep = false;
		}

		else {
			if (asleep) {
				sleepTimer -= Time.fixedDeltaTime;
				if (sleepTimer <= 0) {
					asleep = false;
					sleepTimer = 7.0f;
					GetComponent<Animator> ().SetBool ("awake", true);
				}
			} else if (!asleep) {
				if (!sighted) {
					awakeTimer -= Time.fixedDeltaTime;
					attackTimer = 1.5f;
				}
				Detect ();
				if (awakeTimer <= 0 && !sighted) {
					asleep = true;
					awakeTimer = 7.0f;
					GetComponent<Animator> ().SetBool ("awake", false);
				} else if (sighted) {
					attackTimer -= Time.fixedDeltaTime;
					if (attackTimer <= 0 && sighted) {
						GetComponentInChildren<AudioSource> ().PlayOneShot (gunShot);//********************************************
						player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.RANGED);
						attackTimer = 1.5f;
					}
				}
			}
		}
	}


	void Detect()
	{
		if (!face)
		{
			if (Mathf.Abs (player.transform.position.x - this.transform.position.x) < detRange 
				&& Mathf.Abs (player.transform.position.y - this.transform.position.y) < 1.0f
				&& player.transform.position.x > this.transform.position.x) 
			{
				if (player.GetComponent<Invisiblilityscript> ().LightExposure () > 1)
				{
					sighted = true;
					GetComponent<Animator> ().SetBool ("Fire", true);
				}
				else
				{
					sighted = false;
					GetComponent<Animator>().SetBool("Fire", false);
				}
			} else {
				sighted = false;
				GetComponent<Animator>().SetBool("Fire", false);
			}
		}
		else 
		{
			if (Mathf.Abs (player.transform.position.x - this.transform.position.x) < detRange 
			    && Mathf.Abs (player.transform.position.y - this.transform.position.y) < 1.0f
			    && player.transform.position.x < this.transform.position.x) 
			{
				if (player.GetComponent<Invisiblilityscript> ().LightExposure () > 1)
				{
					sighted = true;
					GetComponent<Animator> ().SetBool ("Fire", true);
				}
				else
				{
					sighted = false;
					GetComponent<Animator>().SetBool("Fire", false);
				}
			} else {
				sighted = false;
				GetComponent<Animator>().SetBool("Fire", false);
			}
		}
	
	}


}
