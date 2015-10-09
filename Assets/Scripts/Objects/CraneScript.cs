using UnityEngine;
using System.Collections;

public class CraneScript : MonoBehaviour {

	public GameObject player;
	public GameObject rope;
	public GameObject crate;
	public GameObject grappleHook;

	bool trigger;
	float inputNumber = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if (grappleHook == null) {
			grappleHook = GameObject.FindGameObjectWithTag("GrappleHook");
		}
		if (trigger == true) 
		{
			if(Input.GetKeyDown(KeyCode.E) && inputNumber == 0)
			{
			player.GetComponent<PlayerController>().moveSpeed = 0;
				grappleHook.GetComponent<GrappleHookScript>().enabled = false;
				inputNumber = 1;
			}
			else if(Input.GetKeyDown(KeyCode.E) && inputNumber == 1)
			{
				player.GetComponent<PlayerController>().moveSpeed = 5;
				grappleHook.GetComponent<GrappleHookScript>().enabled = true;
				inputNumber = 0;
			}
		}

		if (inputNumber == 1) 
		{
			if(Input.GetKey(KeyCode.W))
			{
				if(crate.GetComponent<CrateScript>().moveUp == true)
				{
					Vector3 temp = rope.transform.localScale;
					temp.y = temp.y - .005f;
					rope.transform.localScale = temp;
				}
			}
			else if (Input.GetKey(KeyCode.S))
			{
				if(crate.GetComponent<CrateScript>().moveDown == true)
				{
					Vector3 temp = rope.transform.localScale;
					temp.y = temp.y + .005f;
					rope.transform.localScale = temp;
				}
			}
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			trigger = true;
			player = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			trigger = false;
		}
	}



}
