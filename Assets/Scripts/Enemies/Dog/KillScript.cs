﻿using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			GetComponentInParent<AudioSource>().Stop ();
			GetComponentInParent<AudioSource>().PlayOneShot(GetComponentInParent<AudioSource>().clip);
			GetComponentInParent<DogBehavior> ().Player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);
			GetComponentInChildren<ParticleSystem>().Play();
			//TEST CODE ONLY, DO NOT USE FOR FINAL TURN IN
			//GetComponentInParent<DogBehavior>().Player.SetActive(false);
			GetComponentInParent<DogBehavior>().state = ENMY_STATES.PATROL;



		}
	}
}
