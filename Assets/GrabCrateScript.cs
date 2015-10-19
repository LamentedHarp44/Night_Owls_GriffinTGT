using UnityEngine;
using System.Collections;

public class GrabCrateScript : MonoBehaviour {


	GameObject player;
	GameObject grappleHook;
	GameObject grappleHookStart;
	public bool dragToPlayer = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindWithTag ("Player");
		if (grappleHook == null)
			grappleHook = GameObject.FindWithTag ("GrappleHook");
		if (grappleHookStart == null)
			grappleHookStart = GameObject.FindWithTag ("GrappleHookStart");

		if (dragToPlayer == true) 
		{
			GetComponent<Rigidbody2D>().gravityScale = 0;
			transform.position = Vector3.MoveTowards(transform.position, grappleHookStart.transform.position, 5 * Time.deltaTime);
		}

		if (grappleHook.GetComponent<GrappleHookScript> ().shot == false) 
		{
			dragToPlayer = false;
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "GrappleHook" && grappleHook.GetComponent<GrappleHookScript>().shot == true
		    && grappleHook.GetComponent<GrappleHookScript>().GAPurchased == true)
		{
			dragToPlayer = true;
			player.GetComponent<PlayerController>().moveSpeed = 0;
			grappleHook.GetComponent<GrappleHookScript>().grabbedCrate = true;
		}

		if (other.tag == "GrappleHookStart") 
		{
			dragToPlayer = false;
			GetComponent<Rigidbody2D>().gravityScale = 1;
			player.GetComponent<PlayerController>().moveSpeed = 5;
			grappleHook.GetComponent<GrappleHookScript>().shot = false;
			grappleHook.GetComponent<GrappleHookScript>().grabbedCrate = false;
		}
	}


}
