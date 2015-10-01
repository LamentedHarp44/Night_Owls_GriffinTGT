using UnityEngine;
using System.Collections;

public class LittleTimmy : MonoBehaviour {

	//  Little Timmy does need a player reference
	GameObject playerRef;
	//  Little Timmy does need a reaction range
	float reactionRange = 4.0f;
	//  The player recieves an award for interacting with Timmy
	int valuable;
	//  Little Timmy needs two booleans for use in the KnockDown()
	bool playerInCollider, playerIsInvisible, beenPushedThisLevel, timmyIsHiding, timmyHasTaunted; 
	//  Some sounds for taunts
	public AudioClip snicker, taunt;
	//  A delay between taunts
	float delay;
	// Use this for initialization
	void Start () 
	{
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		valuable = Random.Range (1, 100);
		beenPushedThisLevel = false;
		timmyHasTaunted = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerRef == null)
			playerRef = GameObject.FindGameObjectWithTag ("Player");

		//  Is the player Invisible
		if (playerRef.GetComponent<Invisiblilityscript> ().IsActive ()) 
		{
			playerIsInvisible = true;
		} 
		else playerIsInvisible = false;


		if (!beenPushedThisLevel) {
			if (!playerIsInvisible && Mathf.Abs (playerRef.transform.position.x - transform.position.x) < reactionRange && !timmyIsHiding) {
				//  Hide
				GetComponent<Animator> ().SetTrigger ("Hide");

				timmyIsHiding = true;
			} else if (timmyIsHiding && Mathf.Abs (playerRef.transform.position.x - transform.position.x) > reactionRange || playerIsInvisible) {
				timmyIsHiding = false;

				GetComponent<Animator> ().SetTrigger ("Search");
			}
		}

		if (timmyIsHiding)
		{
			if (delay <= 0 && timmyHasTaunted)
			{
				delay = Random.Range(3.0f, 6.0f);

				timmyHasTaunted = false;
			}

			if (delay > 0)
			{
				delay -= Time.deltaTime;

				if (!timmyHasTaunted)
				{
					int whichSound = Random.Range (0, 20);

					if (whichSound >= 0 && whichSound < 6)
					{
						GetComponentInChildren<AudioSource>().PlayOneShot(snicker);
					}
					else if (whichSound >= 8 && whichSound < 12)
					{
						GetComponentInChildren<AudioSource>().PlayOneShot(taunt);
					}

					timmyHasTaunted = true;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			playerInCollider = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			playerInCollider = false;
		}
	}

	public int KnockDown()
	{
		if (playerIsInvisible && playerInCollider && !beenPushedThisLevel && !timmyIsHiding) 
		{ 
			beenPushedThisLevel = true;

			//  "Trip"
			GetComponent<Animator>().SetTrigger("KnockDown");

			return valuable;
		}

		return 0;
	}
}
