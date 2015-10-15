using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			GetComponentInParent<AudioSource> ().Stop ();
			GetComponentInParent<DogBehavior> ().SFXVolume.PlayOneShot (GetComponentInParent<DogBehavior> ().SFXVolume.clip);
			GetComponentInParent<DogBehavior> ().Player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);
			GetComponentInChildren<ParticleSystem> ().Play ();
			//TEST CODE ONLY, DO NOT USE FOR FINAL TURN IN
			//GetComponentInParent<DogBehavior>().Player.SetActive(false);
			GetComponentInParent<DogBehavior> ().state = ENMY_STATES.PATROL;
		} else if (col.gameObject.CompareTag ("Wall")) {
			GetComponentInParent<DogBehavior> ().face = !GetComponentInParent<DogBehavior> ().face;
			GetComponentInParent<DogBehavior> ().state = ENMY_STATES.PATROL;
		} else if (col.gameObject.CompareTag ("chest")) {
			GetComponentInParent<DogBehavior> ().state = ENMY_STATES.RESET;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Waypoint")) 
		{
			if (GetComponentInParent<DogBehavior>().state == ENMY_STATES.PATROL)
				GetComponentInParent<DogBehavior>().face = !GetComponentInParent<DogBehavior>().face;
			
			else
			{
				GetComponentInParent<DogBehavior>().state = ENMY_STATES.PATROL;
				
				GetComponentInParent<DogBehavior>().face = !GetComponentInParent<DogBehavior>().face;
			}
		}
	}

}
