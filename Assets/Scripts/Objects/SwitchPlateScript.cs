using UnityEngine;
using System.Collections;

public class SwitchPlateScript : MonoBehaviour {

	Animator anim;
	public GameObject trapDoor;
	bool triggered = false;
	public AudioSource soundEFX;
	bool play = false;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (triggered) 
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				anim.SetBool("Triggered", true);
				if(play)
				{
					soundEFX.Play();
					play = false;
				}
				trapDoor.GetComponent<BoxCollider2D>().enabled = false;
				trapDoor.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{

			triggered = true;
			play = true;
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			triggered = false;
		}
	}


}
