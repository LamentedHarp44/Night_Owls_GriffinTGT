using UnityEngine;
using System.Collections;

public class FloorHazardKillScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			player.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.TRAP);
		}
	}


}
