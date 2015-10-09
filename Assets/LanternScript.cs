using UnityEngine;
using System.Collections;

public class LanternScript : MonoBehaviour {

	bool BladeAttachmentPurchased = false;
	GameObject player;
	GameObject grappleHook;
	GameObject lightLayer1;
	GameObject lightLayer2;
	GameObject lightLayer3;
	bool lightOut = false;
	float timer = 0;
	public AudioSource SoundEFX;

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
		if (lightLayer1 == null)
			lightLayer1 = GameObject.FindWithTag ("LightLayer1");
		if (lightLayer2 == null)
			lightLayer2 = GameObject.FindWithTag ("LightLayer2");
		if (lightLayer3 == null)
			lightLayer3 = GameObject.FindWithTag ("LightLayer3");


		BladeAttachmentPurchased = grappleHook.GetComponent<GrappleHookScript> ().BAPurchased;


		if (lightOut == true) 
		{
			timer += Time.deltaTime;

			if(timer >= 5.00f)
			{
				GetComponentInChildren<Light>().enabled = true;
				lightLayer1.GetComponent<BoxCollider2D>().enabled = true;
				lightLayer2.GetComponent<BoxCollider2D>().enabled = true;
				lightLayer3.GetComponent<BoxCollider2D>().enabled = true;
				timer = 0;
				lightOut = false;
			}
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "GrappleHook" && grappleHook.GetComponent<GrappleHookScript>().shot == true && BladeAttachmentPurchased == true
		    && lightOut == false)
		{
			GetComponentInChildren<Light>().enabled = false;
			lightLayer1.GetComponent<BoxCollider2D>().enabled = false;
			lightLayer2.GetComponent<BoxCollider2D>().enabled = false;
			lightLayer3.GetComponent<BoxCollider2D>().enabled = false;

			if(player.GetComponent<PlayerController>().lightExpoPurchased == true)
				player.GetComponent<PlayerController>().lightExpo = -2;
			else
				player.GetComponent<PlayerController>().lightExpo = 0;

			grappleHook.GetComponent<GrappleHookScript>().shot = false;

			lightOut = true;

			SoundEFX.Play();
		}

	}

}
