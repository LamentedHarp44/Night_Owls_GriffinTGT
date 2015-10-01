using UnityEngine;
using System.Collections;

public class MalformedPatientDetectScript : MonoBehaviour {

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
			GetComponentInParent<ExperimentBehavior>().inDetectionRange = true;
			GetComponentInParent<ExperimentBehavior>().SFXVolume.PlayOneShot(GetComponentInParent<ExperimentBehavior>().idle);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			GetComponentInParent<ExperimentBehavior>().inDetectionRange = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if(player.GetComponent<PlayerController>().moving == true)
				GetComponentInParent<ExperimentBehavior>().playerMoving = true;
			else
				GetComponentInParent<ExperimentBehavior>().playerMoving = false;
		}
	}


}
