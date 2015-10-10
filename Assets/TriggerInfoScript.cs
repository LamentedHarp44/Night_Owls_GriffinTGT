using UnityEngine;
using System.Collections;

public class TriggerInfoScript : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}

}
