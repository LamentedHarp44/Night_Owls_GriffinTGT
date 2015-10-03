using UnityEngine;
using System.Collections;

public class FloorHazardKillScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			player.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.TRAP);
		}
	}


}
