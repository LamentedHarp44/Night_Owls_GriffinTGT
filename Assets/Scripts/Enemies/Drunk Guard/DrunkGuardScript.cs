using UnityEngine;
using System.Collections;

public class DrunkGuardScript : MonoBehaviour {
	enum MentalState{DRUNKEN, AWAKE};
	enum PhysicalState{NONTHREAT, AGGRESSIVE};
	GameObject player;
	float awakeTime;
	float drunkTime;
	float alertDistance;
	int mState;
	int pState;
	public AudioSource audSnore;
	public AudioSource audShot;
	public AudioClip alert;

	public Animator drunkenAnim;
	public Animator shotAnim;
	public Animator awakeAnim;

	public float dt;
	/*Player.GetComponent<Invisiblilityscript> ().VisCheck();
	 */

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
		mState = (int)(MentalState.DRUNKEN);
		pState = (int)(PhysicalState.NONTHREAT);
		awakeTime = 3.0f;
		drunkTime = 3.0f;
		alertDistance = 10.0f;
		InvokeRepeating("ChangeState",3.0f,awakeTime);
		audSnore.mute = false;
		audSnore.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		// Shot player once per 5s
		if (pState == (int)(PhysicalState.AGGRESSIVE))
			Shot ();
	}

	void ChangeMentalStateState(){
		if (mState == (int)(MentalState.DRUNKEN)) {
			mState = (int)(MentalState.AWAKE);
			audSnore.mute = false;
		} else {
			mState = (int)(MentalState.DRUNKEN);
			audSnore.mute = true;
		}
	}

	void Shot(){

		audShot.Play();
		/*shotAnim.Play ("Shot");*/
		player.GetComponent<PlayerController> ().lives -= 1;
		if (player.GetComponent<PlayerController> ().lives < 0)
			player.GetComponent<PlayerController> ().lives = 3;

	}

	void DetectPlayer(){
		if (mState == (int)(MentalState.DRUNKEN)) {
			pState=(int)(PhysicalState.NONTHREAT);
			return;
		}

		float distance;
		distance= Vector3.Distance (player.transform.position, this.transform.position);

		if (distance < alertDistance)
			             pState=(int)(PhysicalState.AGGRESSIVE);
		else
			             pState=(int)(PhysicalState.NONTHREAT);

	
	}


}
