using UnityEngine;
using System.Collections;

public class InteractionAlertBehavior : MonoBehaviour {
	float previousDelay;
	bool inUse;
	public GameObject parent;
	int UndetectedSearchPurchaseTracker = 0;
	bool UndetectedSearchPurchased = false;

	// Use this for initialization
	void Start () {
		if (parent.CompareTag ("chest"))
			previousDelay = GetComponentInParent<containerscript> ().normDelay;
		else
			previousDelay = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UndetectedSearchPurchaseTracker = PlayerPrefs.GetInt ("UndetectedSearch");
		if (UndetectedSearchPurchaseTracker == 1) 
		{
			UndetectedSearchPurchased = true;
			PlayerPrefs.SetInt("UndetectedSearch", 0);
		}

		if (UndetectedSearchPurchased == false) 
		{
			if (parent.CompareTag ("chest")) {

				if (parent.GetComponent<containerscript> ().delay < parent.GetComponent<containerscript> ().normDelay &&
					parent.GetComponent<containerscript> ().delay >= 0.0f && parent.GetComponent<containerscript> ().delay < previousDelay) {
					inUse = true;
				} else
					inUse = false;


				previousDelay = GetComponentInParent<containerscript> ().delay;
			} else if (parent.CompareTag ("Floor Hazard")) {
				if (parent.GetComponent<FloorNoiseScript> ().steppedOn == true) 
				{
					inUse = true;
				} 
				else
					inUse = false;
			}	
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag ("Player") && !other.gameObject.CompareTag ("Untagged")
		    && !other.gameObject.CompareTag ("Floor") && !other.gameObject.CompareTag("GrappleHook") && !other.gameObject.CompareTag("GrappleGun")) 
		{
			if (UndetectedSearchPurchased == false) 
			{
				if (other.CompareTag ("PatrollingGuard") && inUse && 
					(other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.SEARCH 
					|| other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.ATTACK)) 
				{
					other.gameObject.GetComponent<GuardBehavior> ().targPos = this.transform.position;

					other.gameObject.GetComponent<GuardBehavior> ().ChangeENMYState (ENMY_STATES.SEARCH);
				} 
				else if (other.CompareTag ("Malformed Patient") && inUse && other.gameObject.GetComponent<ExperimentBehavior>().state != ENMY_STATES.ATTACK) {
					other.gameObject.GetComponent<ExperimentBehavior> ().state = ENMY_STATES.ATTACK;
				}
				else if (other.CompareTag ("Dog") && inUse && (other.gameObject.GetComponentInParent<DogBehavior> ().state != ENMY_STATES.SEARCH ||
					other.gameObject.GetComponentInParent<DogBehavior> ().state != ENMY_STATES.ATTACK)) 
				{
					other.gameObject.GetComponentInParent<DogBehavior> ().target = this.transform.position;
			
					other.gameObject.GetComponentInParent<DogBehavior> ().state = ENMY_STATES.SEARCH;
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag ("Player") && !other.gameObject.CompareTag ("Untagged")
			&& !other.gameObject.CompareTag ("Floor") && !other.gameObject.CompareTag("GrappleHook") && !other.gameObject.CompareTag("GrappleGun")) 
		{
			if (UndetectedSearchPurchased == false) 
			{
				if (other.CompareTag ("PatrollingGuard") && inUse &&
					other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.SEARCH 
					&& other.gameObject.GetComponent<GuardBehavior> ().currState != ENMY_STATES.ATTACK) 
				{
					other.gameObject.GetComponent<GuardBehavior> ().targPos = this.transform.position;
			
					other.gameObject.GetComponent<GuardBehavior> ().ChangeENMYState (ENMY_STATES.SEARCH);
				} 
				else if (other.CompareTag ("Malformed Patient") && inUse && other.gameObject.GetComponent<ExperimentBehavior>().state != ENMY_STATES.ATTACK) 
				{
					other.gameObject.GetComponent<ExperimentBehavior> ().state = ENMY_STATES.ATTACK;
				} 
				else if (other.CompareTag ("Dog") && inUse && other.gameObject.GetComponentInParent<DogBehavior> ().state != ENMY_STATES.SEARCH &&
					other.gameObject.GetComponentInParent<DogBehavior> ().state != ENMY_STATES.ATTACK) 
				{
					other.gameObject.GetComponentInParent<DogBehavior> ().target = this.transform.position;
			
					other.gameObject.GetComponentInParent<DogBehavior> ().state = ENMY_STATES.SEARCH;
				}
			}
		}
	}
}
