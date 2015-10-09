using UnityEngine;
using System.Collections;

public class ExperimentBehavior : MonoBehaviour {


	public float walkSpd, attackSpd;
	public ENMY_STATES state;
	GameObject player;
	public SpriteRenderer xMark;
	public float leash = 5.0f;
	bool face;
	public Vector3 anchor;
	public bool inDetectionRange;
	public bool playerMoving;
	bool killedPlayer;
	float timer;
	public AudioClip idle;
	public AudioClip detect;
	public AudioSource SFXVolume;


	// Use this for initialization
	void Start () 
	{
		anchor = transform.position;
		walkSpd = 1.5f;
		attackSpd = 5.5f;
		face = true;
		state = ENMY_STATES.PATROL;
		inDetectionRange = false;
		playerMoving = false;
		killedPlayer = false;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If player doesn't exist set him.
		if(player == null)
			player = GameObject.FindWithTag ("Player");

		//Set attack state alert image.
		if (state == ENMY_STATES.ATTACK)
			xMark.enabled = true;
		else
			xMark.enabled = false;

		//Resetting player killed variables for malformed patient.
		if (killedPlayer == true)
			timer += Time.deltaTime;
		if (timer > 1.0f) 
		{
			GetComponent<BoxCollider2D> ().enabled = true;
			killedPlayer = false;
			timer = 0;
		}

		//Setting A.I. behavior.
		switch (state) 
		{
		case ENMY_STATES.PATROL:
			PatrolBehavior();
			break;
		case ENMY_STATES.ATTACK:
			AttackBehavior();
			break;
		}

		//This just flips the image.
		if (face) 
		{
			Vector3 temp = transform.localScale;
			 temp.x = -3;
			transform.localScale = temp;
		} 
		else 
		{
			Vector3 temp = transform.localScale;
			temp.x = 3;
			transform.localScale = temp;
		}
	}

	void PatrolBehavior()
	{
		//check to see if at end of leash
		if (transform.position.x - leash > anchor.x && face)
			face = false;
		else if (transform.position.x + leash < anchor.x && !face)
			face = true;
		
		//movement
		Vector3 temp = transform.position;
		
		if (face)
			temp.x += walkSpd * Time.fixedDeltaTime;
		else
			temp.x -= walkSpd * Time.fixedDeltaTime;
		
		transform.position = temp;

		//If the player is in range and he is moving go into attack state.
		if (inDetectionRange == true && playerMoving == true && player.GetComponent<PlayerController>().hiding == false) 
		{
			state = ENMY_STATES.ATTACK;
			SFXVolume.PlayOneShot(detect);
		}
	}

	void AttackBehavior()
	{
		Vector3 temp = transform.position;
		
		if (transform.position.x < player.transform.position.x && !face)
			face = true;
		else if (transform.position.x > player.transform.position.x && face)
			face = false;
		
		if (face)
			temp.x += attackSpd * Time.fixedDeltaTime;
		else 
			temp.x -= attackSpd * Time.fixedDeltaTime;
		
		transform.position = temp;

		if (playerMoving == false || player.GetComponent<PlayerController>().hiding == true)//inDetectionRange == false || 
			state = ENMY_STATES.PATROL;
	}


//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.tag == "Player" && playerMoving == true) 
//		{
//			player.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.MELEE);
//		}
//	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" && playerMoving == true)
		{
			GetComponent<BoxCollider2D>().enabled = false;
			player.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.MELEE);
			killedPlayer = true;
		}
	}


}
