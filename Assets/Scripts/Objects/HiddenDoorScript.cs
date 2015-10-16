using UnityEngine;
using System.Collections;

public class HiddenDoorScript : MonoBehaviour {

	Animator anim;
	GameObject player;
	GameObject grappleGun;
	GameObject grappleHook;
	bool goHiding;
	public bool hiding;
	float inputCount;

	// Use this for initialization
	void Start () 
	{
		goHiding = false;
		hiding = false;
		inputCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Pause") != null && !GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) 
		{

			if (player == null) 
			{
				player = GameObject.FindWithTag ("Player");
				grappleGun = GameObject.FindWithTag ("GrappleGun");
				grappleHook = GameObject.FindWithTag ("GrappleHook");
				anim = player.GetComponent<Animator> ();
			}

			if(goHiding == true)
			{
				if(Input.GetKeyDown(KeyCode.E) && inputCount == 0)
				{
					ActivateHiding();
					hiding = true;
					player.GetComponent<PlayerController> ().lightExpo = 0;
					player.GetComponent<SpriteRenderer>().sortingOrder = 1;
				}
				else if (Input.GetKeyDown(KeyCode.E) && inputCount == 1)
				{
					DeactivateHiding();
					hiding = false;
					player.GetComponent<SpriteRenderer>().sortingOrder = 5;
					if(player.GetComponent<PlayerController>().lightExpoPurchased == false)
						player.GetComponent<PlayerController> ().lightExpo = 0;
					else
						player.GetComponent<PlayerController> ().lightExpo = -2;
				} 
			}

		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			goHiding = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			goHiding = false;
		}
	}

	void ActivateHiding()
	{
		anim.SetBool("Hidden", true);
		inputCount++;
		player.transform.position = transform.position;
		player.GetComponent<Rigidbody2D>().gravityScale = 0;
		player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		player.GetComponent<BoxCollider2D>().enabled = false;
		player.GetComponent<PlayerController>().moveSpeed = 0;
		player.GetComponent<PlayerController>().grounded = false;
		grappleGun.GetComponent<SpriteRenderer>().enabled = false;
		grappleHook.GetComponent<SpriteRenderer>().enabled = false;
		grappleHook.GetComponent<GrappleHookScript>().enabled = false;
	}

	public void DeactivateHiding()
	{
		anim.SetBool("Hidden", false);
		inputCount = 0;
		player.GetComponent<Rigidbody2D>().gravityScale = 1;
		player.GetComponent<BoxCollider2D>().enabled = true;
		player.GetComponent<PlayerController>().moveSpeed = 5;
		player.GetComponent<PlayerController>().grounded = true;
		grappleGun.GetComponent<SpriteRenderer>().enabled = true;
		grappleHook.GetComponent<SpriteRenderer>().enabled = true;
		grappleHook.GetComponent<GrappleHookScript>().enabled = true;
	}

}
