

using UnityEngine;
using System.Collections;


public class DogBehavior : MonoBehaviour {

	public bool face;
	// facing left = false, right = true
	public float walkSpeed = 3;
	float srchSpeed;
	float atkSpeed;
	public ENMY_STATES state;
	public GameObject Player;
	public GameObject Alert;
	public float delay;
	public float leash = 3;
	public float alertDelay;
	public Vector3 anchor;
	public bool scent;
	public Vector3 target;
	public float detRange;
	public float searchTime;
	public float atkTime;
	public AudioClip growl;
	public AudioClip bark;
	public AudioClip sniff;
	public AudioClip whimper;
	public AudioSource SFXVolume;
	// Use this for initialization
	void Start () 
	{
		anchor = transform.position;
		state = ENMY_STATES.PATROL;
		//walkSpeed = 3;
		srchSpeed = 2;
		atkSpeed = 5;
		face = true;
		delay = 30.0f;
		//leash = 3;
		scent = false;
		detRange = 2.0f;
		searchTime = 5.0f;
		atkTime = 3.0f;
		alertDelay = .5f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Player == null)
			Player = GameObject.FindGameObjectWithTag ("Player");

		if (GameObject.FindGameObjectWithTag ("Pause") != null && !GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {

			if (!scent)
				Detect ();
			else 
				ScentDetect ();

			switch (state) {
			case ENMY_STATES.PATROL:
				PatrolBehavior ();
				break;
			case ENMY_STATES.SEARCH:
				SearchBehavior ();
				break;
			case ENMY_STATES.ATTACK:
				AttackBehavior ();
				break;
			case ENMY_STATES.RESET:
				Reset ();
				break;
			}
		}
	}

	void PatrolBehavior ()
	{
		//check to see if at end of leash
		if (transform.position.x - leash > anchor.x && face)
			face = false;
		else if (transform.position.x + leash < anchor.x && !face)
			face = true;

		//movement
		Vector3 temp = transform.position;

		if (face)
			temp.x += walkSpeed * Time.fixedDeltaTime;
		else
			temp.x -= walkSpeed * Time.fixedDeltaTime;

		transform.position = temp;		
	}

	void SearchBehavior ()
	{
		if (alertDelay > 0) 
		{
			alertDelay -= Time.fixedDeltaTime;
			Alert.GetComponent<SpriteRenderer>().enabled = true;
		} 
		else 
		{
			Alert.GetComponent<SpriteRenderer>().enabled = false;
		
			Vector3 temp = transform.position;

			if (transform.position.x < target.x && !face)
				face = true;
			else if (transform.position.x > target.x && face)
				face = false;

			if (face)
				temp.x += srchSpeed * Time.fixedDeltaTime;
			else 
				temp.x -= srchSpeed * Time.fixedDeltaTime;

			transform.position = temp;
		}
	}
	void AttackBehavior ()
	{
		Vector3 temp = transform.position;
		
		if (transform.position.x < Player.transform.position.x && !face)
			face = true;
		else if (transform.position.x > Player.transform.position.x && face)
			face = false;
		
		if (face)
			temp.x += atkSpeed * Time.fixedDeltaTime;
		else 
			temp.x -= atkSpeed * Time.fixedDeltaTime;
		
		transform.position = temp;
	}

	void Reset()
	{
		if (face && transform.position.x > anchor.x)
			face = false;
		else if (!face && transform.position.x < anchor.x)
			face = true;

		Vector3 temp = transform.position;

		if (face)
			temp.x += walkSpeed * Time.fixedDeltaTime;
		else 
			temp.x -= walkSpeed * Time.fixedDeltaTime;

		transform.position = temp;

		if (transform.position.x + .1 > anchor.x || transform.position.x - .1 < anchor.x) 
		{
			state = ENMY_STATES.PATROL;
			//GetComponent<AudioSource>().Stop ();
			//GetComponent<AudioSource>().PlayOneShot(sniff);
			SFXVolume.Stop();
			SFXVolume.PlayOneShot(sniff);
		}
	}





	void Detect()
	{

		if (Player.GetComponent<PlayerController> ().lightExpo > 0) {
			float tempRange = detRange * Player.GetComponent<Invisiblilityscript> ().LightExposure ();
			RaycastHit2D targ;

			if (state == ENMY_STATES.PATROL) {
				if (!face)
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.left, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);
				else
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.right, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);

				if (targ.collider != null && targ.collider.gameObject.tag == "Player") {
					target = targ.transform.position;
					state = ENMY_STATES.SEARCH;
					alertDelay = .5f;
					//GetComponent<AudioSource> ().Stop ();
					//GetComponent<AudioSource> ().PlayOneShot (growl);
					SFXVolume.Stop();
					SFXVolume.PlayOneShot(growl);
				} else
					return;
			} else if (state == ENMY_STATES.SEARCH) {
				if (!face)
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.left, detRange, Physics2D.DefaultRaycastLayers, -1.0f);
				else 
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.right, detRange, Physics2D.DefaultRaycastLayers, -1.0f);

				if (targ.collider != null && targ.collider.gameObject.tag == "Player") {
					//GetComponent<AudioSource> ().Stop ();
					//GetComponent<AudioSource> ().PlayOneShot (bark);
					SFXVolume.Stop();
					SFXVolume.PlayOneShot(bark);
					state = ENMY_STATES.ATTACK;
					return;
				} else {
					if (!face)
						targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.left, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);
					else
						targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.right, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);
				}

				if (targ.collider != null && targ.collider.gameObject.tag == "Player") {
					target = targ.transform.position;
				} else {
					searchTime -= Time.fixedDeltaTime;
					if (searchTime <= 0) {
						searchTime = 5.0f;
						state = ENMY_STATES.RESET;
						//GetComponent<AudioSource> ().Stop ();
						//GetComponent<AudioSource> ().PlayOneShot (whimper);
						SFXVolume.Stop();
						SFXVolume.PlayOneShot(whimper);
					} else
						return;
				}
			} else if (state == ENMY_STATES.ATTACK) {
				if (!face)
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.left, detRange, Physics2D.DefaultRaycastLayers, -1.0f);
				else 
					targ = Physics2D.Raycast ((Vector2)transform.position, Vector2.right, detRange, Physics2D.DefaultRaycastLayers, -1.0f);

				if (targ.collider == null || targ.collider.gameObject.tag != "Player") {
					atkTime -= Time.fixedDeltaTime;

					if (atkTime <= 0) {
						atkTime = 3.0f;
						state = ENMY_STATES.SEARCH;
						//GetComponent<AudioSource> ().Stop ();
						//GetComponent<AudioSource> ().PlayOneShot (growl);
						SFXVolume.Stop();
						SFXVolume.PlayOneShot(growl);
					}
				} else
					return;
			}

		}
	}

	void ScentDetect()
	{
		if (state == ENMY_STATES.PATROL || state == ENMY_STATES.RESET) {
			state = ENMY_STATES.SEARCH;
			target = Player.transform.position;

		} 
		else if (state == ENMY_STATES.SEARCH) 
		{
			delay -= Time.fixedDeltaTime;
			if (delay <= 0)
				state = ENMY_STATES.ATTACK;
		}
	}




}
