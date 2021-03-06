﻿using UnityEngine;
using System.Collections;

public class FloorNoiseScript : MonoBehaviour {
	public AudioClip glassCrunch;
	public AudioSource source;
	public bool steppedOn;
	float cd;
	// Use this for initialization
	void Start () {
		cd = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (steppedOn) {
			cd -= Time.fixedDeltaTime;

			if (cd <= 0)
			{
				steppedOn = false;

				cd = .5f;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && !steppedOn) {
			source.PlayOneShot(glassCrunch);

			steppedOn = true;
		}
	}
}
