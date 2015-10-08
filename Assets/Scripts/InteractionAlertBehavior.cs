using UnityEngine;
using System.Collections;

public class InteractionAlertBehavior : MonoBehaviour {
	float previousDelay;
	bool inUse;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		if (parent.CompareTag("chest"))
		previousDelay = GetComponentInParent<containerscript> ().normDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (parent.CompareTag ("chest")) 
		{
			if (GetComponentInParent<containerscript> ().delay < GetComponentInParent<containerscript> ().normDelay &&
				GetComponentInParent<containerscript> ().delay >= 0.0f  && GetComponentInParent<containerscript>().delay < previousDelay) {
				inUse = true;
			} else
				inUse = false;

			previousDelay = GetComponentInParent<containerscript>().delay;
		}
		else if (parent.CompareTag ("Floor Hazard")) 
		{
			if (parent.GetComponent<FloorNoiseScript>().steppedOn == true)
			{
				inUse = true;
			}
			else
				inUse = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag ("PatrollingGuard") && inUse && 
		    (other.gameObject.GetComponent<GuardBehavior>().currState != ENMY_STATES.SEARCH 
		 	|| other.gameObject.GetComponent<GuardBehavior>().currState != ENMY_STATES.ATTACK)) 
		{
			other.gameObject.GetComponent<GuardBehavior>().targPos = this.transform.position;

			other.gameObject.GetComponent<GuardBehavior>().ChangeENMYState(ENMY_STATES.SEARCH);
		}
		else if (other.CompareTag ("Malformed Patient") && inUse &&
		         (other.gameObject.GetComponent<ExperimentBehavior> ().state != ENMY_STATES.ATTACK)) 
		{
			other.gameObject.GetComponent<ExperimentBehavior>().state = ENMY_STATES.ATTACK;
		}
		else if (other.CompareTag ("Dog") && inUse && (other.gameObject.GetComponent<DogBehavior> ().state != ENMY_STATES.SEARCH ||
		                                               other.gameObject.GetComponent<DogBehavior> ().state != ENMY_STATES.ATTACK)) {
			other.gameObject.GetComponent<DogBehavior> ().target = this.transform.position;
			
			other.gameObject.GetComponent<DogBehavior> ().state = ENMY_STATES.SEARCH;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("PatrollingGuard") && inUse &&
			other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.SEARCH 
			&& other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.ATTACK) {
			other.gameObject.GetComponent<GuardBehavior> ().targPos = this.transform.position;
			
			other.gameObject.GetComponent<GuardBehavior> ().ChangeENMYState (ENMY_STATES.SEARCH);
		} else if (other.CompareTag ("Malformed Patient") && inUse &&
			other.gameObject.GetComponent<ExperimentBehavior> ().state != ENMY_STATES.ATTACK) {
			other.gameObject.GetComponent<ExperimentBehavior> ().state = ENMY_STATES.ATTACK;
		} else if (other.CompareTag ("Dog") && inUse && other.gameObject.GetComponent<DogBehavior> ().state != ENMY_STATES.SEARCH &&
			other.gameObject.GetComponent<DogBehavior> ().state != ENMY_STATES.ATTACK) {
			other.gameObject.GetComponent<DogBehavior> ().target = this.transform.position;
			
			other.gameObject.GetComponent<DogBehavior> ().state = ENMY_STATES.SEARCH;
		}
	}
}
