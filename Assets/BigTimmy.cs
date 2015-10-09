﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigTimmy : MonoBehaviour {

	//  Timmy needs to have an amount of health.
	public int tHealth;
	//  Timmy will slowly chase the player.
	GameObject playerRef;
	//  Timmy will need a movement speed at which to aproach the player.
	float moveSpeed, agressionDuration, agressionInterval, jumpInterval;
	Vector3 origin, landingPosition;
	public Sprite openDoor;

	bool agression = false, jumping = false, toOrigin = false, forceApplied = false;
	public bool inArena = false;
	// Use this for initialization
	void Start () {
		origin = this.transform.position;
		//  The movespeed.
		moveSpeed = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {


		//  This will only happen once, when the player is first found in the scene.
		if (playerRef == null && inArena) 
		{
			//  Find the player to reference within the scene.
			playerRef = GameObject.FindGameObjectWithTag ("Player");
			//  tHealth = the number of times that Little Timmy was tripped by the player + 3
			tHealth = playerRef.GetComponent<PlayerController> ().numPush + 3;
		}
		if (tHealth < 1  && inArena) {
			GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>().lvl = "Main Menu";
			Application.LoadLevel("Loading Screen");
		}

		if (playerRef != null) 
		{
			if (tHealth < 3)
				moveSpeed = 2.5f;


			if (!toOrigin)
			{
			if ((playerRef.transform.position.x < this.transform.position.x && moveSpeed > 0.0f) ||
				(playerRef.transform.position.x > this.transform.position.x && moveSpeed < 0.0f))
				moveSpeed = -moveSpeed;
			}
			else
			{
				if ((origin.x < this.transform.position.x && moveSpeed > 0.0f) ||
				    (origin.x > this.transform.position.x && moveSpeed < 0.0f))
					moveSpeed = -moveSpeed;
			}


			//  Will toggle between a very agressive speed, and a slower speed.
			if (agressionInterval <= 0.0f && tHealth > 2 && !jumping)
			{
				agressionInterval = Random.Range(4.0f, 10.0f);
				agression = !agression;
			}
			else if (agressionInterval <= 0.0f && tHealth <= 2 && !jumping)
			{
				agressionInterval = Random.Range(3.0f, 6.0f);
				agression = !agression;
			}
			else if (!jumping)
			{
				if (agression)
				{
					this.transform.position += new Vector3 (moveSpeed * 2.0f, 0.0f, 0.0f) * Time.deltaTime;
					
					if (playerRef.GetComponent<Invisiblilityscript>().LightExposure() < 2)
					{
						agression = false;
					
						agressionInterval = 0.0f;
						agressionDuration = 0.0f;
					}
					else
					{
						agressionDuration -= Time.deltaTime;

						if (agressionDuration < 0.0f)
						{
							agressionDuration = Random.Range(1.5f, 3.0f);
						
							agression = false;
						}
					}
				}
				else
				{
					this.transform.position += new Vector3 (moveSpeed, 0.0f, 0.0f) * Time.deltaTime;
					
					agressionInterval -= Time.deltaTime;
				}


				// if very close to the player, in x but not y, return to the origin.
				if (Mathf.Abs(playerRef.transform.position.x - this.transform.position.x) < 0.5f  &&
				    Mathf.Abs(playerRef.transform.position.y - this.transform.position.y) > 2.0f)
					toOrigin = true;

				else if (Mathf.Abs(playerRef.transform.position.x - this.transform.position.x) < 2.0f &&
				    Mathf.Abs(playerRef.transform.position.y - this.transform.position.y) < 1.5f &&
				         playerRef.GetComponent<Invisiblilityscript>().LightExposure() > 0)
				{
					playerRef.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.MELEE);


					GameObject.FindGameObjectWithTag("Boss Door").GetComponent<BoxCollider2D>().enabled = false;
					GameObject.FindGameObjectWithTag("Boss Door").GetComponent<SpriteRenderer>().sprite = openDoor;
					ResetTimmy();
				}

				if (toOrigin && Mathf.Abs(origin.x - this.transform.position.x) < 0.5f)
					toOrigin = false;

			}

			//  Every now and then, the boss needs to jump and slam.
			if (jumpInterval < 0.0f && tHealth > 2)
			{
				jumpInterval = Random.Range(5.0f, 8.0f);
				jumping = true;
			}
			else if (jumpInterval < 0.0f && tHealth <= 2)
			{
				jumpInterval = Random.Range(2.0f, 5.0f);

				jumping = true;
			}

			if (jumping)
			{
				if (!forceApplied)
				{
					//  Lifts Timmy off the ground
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
					//  Applies a direct upward force
					this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 100000.0f * 1.25f));
					forceApplied = true;

					// Calculates a position for Timmy to land near
					landingPosition = origin + new Vector3(Random.Range(-15f, 15f), 0.0f, 0.0f);
				}

				//  If Timmy had hit (or fallen through) the floor
				else if (this.transform.position.y <= landingPosition.y && forceApplied == true)
				{
					// Make sure he's on the floor
					this.transform.position = new Vector3(this.transform.position.x, landingPosition.y, this.transform.position.z);
					//  Set jumping to false;
					jumping = forceApplied = false;
					//  Shockwave effect?
					//  Destroy all elevators
					GameObject[] temp = GameObject.FindGameObjectsWithTag("Elevator");
					if (temp.Length > 0)
						for (int i = 0; i < temp.Length; ++i)
						{
						Destroy (temp[i]);
						}

					if (Mathf.Abs(playerRef.transform.position.y - this.transform.position.y) < 0.5f)
					{
						//  Stun player
						playerRef.GetComponent<PlayerController>().StunGriffin();
					}
				}
				
				this.transform.position += new Vector3 ((landingPosition.x - this.transform.position.x) / 3.0f, 0.0f, 0.0f) * Time.deltaTime;
			}
			else
				jumpInterval -= Time.deltaTime;
		}
	}
	//  A function to handle the jump-slam action

	//  A function to handle losing health
	public void TakeDamage()
	{
		--tHealth;
	}

	void OnCollision2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Floor")) {
			if (jumping == true) {
				jumping = forceApplied = false;
			}
		}

		if (other.gameObject.CompareTag ("Player")) 
		{
			if (jumping == true)
			{
				playerRef.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.MELEE);
			
				GameObject.FindGameObjectWithTag("Boss Door").GetComponent<BoxCollider2D>().enabled = false;
				GameObject.FindGameObjectWithTag("Boss Door").GetComponent<SpriteRenderer>().sprite = openDoor;
				ResetTimmy();
			}
		}
	}

	public void ResetTimmy()
	{
		playerRef = null;
		inArena = false;
		this.transform.position = origin;

	}
}
