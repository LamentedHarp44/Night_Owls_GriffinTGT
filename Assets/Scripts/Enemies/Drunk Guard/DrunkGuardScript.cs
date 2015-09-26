using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrunkGuardScript : MonoBehaviour {
	GameObject player;
	BoxCollider2D myColliders;
	//GameObject approachAlert;
	public GameObject drunkenGuard;
	public bool awake;
	public bool threaten;
	public float drunkTime;
	public float awakeTime;
	public float alertDistance;
	public float shotDistance;
	public AudioSource audSnore;
	public AudioSource audShot;
	public AudioSource alert;
	public bool shot;
	/**public Animator drunkenAnim;
	public Animator shotAnim;
	public Animator awakeAnim;**/

	Animator aniController;
	float animaterTimer;
	public bool idle;
	public float dt;
	int playerLight;
	bool Destroy;
	/*Player.GetComponent<Invisiblilityscript> ().VisCheck();
	 */

	// Use this for initialization
	void Start () {
		aniController=drunkenGuard.GetComponent<Animator>();
		myColliders=drunkenGuard.GetComponent<BoxCollider2D>();
		myColliders.enabled = true;
		player=GameObject.FindGameObjectWithTag("Player");
		//approachAlert=GameObject.FindWithTag ("approachAlert");
		//approachAlert.GetComponent<Text> ().text = "";
		shot = false;
		awake=false;
		threaten=false;
		drunkTime = 5.0f;
		awakeTime = 50.0f;
		alertDistance = 10.0f;
		shotDistance = 2.5f;
		//InvokeRepeating("ChangeState",5.0f,awakeTime);
		animaterTimer = 0;
		audSnore.mute = false;
		idle = false;
		audSnore.Play ();
		playerLight = player.GetComponent<Invisiblilityscript> ().LightExposure ();

		//aniController.SetFloat ("Speed",0.3f);
		//*awakeAnim.SetFloat("Speed_f",0.3f);*//
	}
	
	// Update is called once per frame
	void Update () {
        
		animaterTimer += Time.deltaTime;

		//Sleeping to awake
		if (animaterTimer >=5 && !awake && !idle) {
			idle=false;
			awake = true;
			animaterTimer=0;
			//aniController.SetBool ("awake", awake);
		}

		//Awake to idle
		if (awake && !idle && animaterTimer==0) {
			idle = true;
			//animaterTimer =0;
			//audSnore.mute = true;
			//animaterTimer=0;

		} 

		if (animaterTimer >=5  && awake && idle) {
			animaterTimer = 0;
			awake = false;
			idle=false;
			//aniController.SetBool ("awake", awake);
		}
	

		aniController.SetBool ("awake", awake);
		aniController.SetFloat ("Timer", animaterTimer);
		aniController.SetBool ("Idle", idle);


		if (awake){
			audSnore.mute = true;
			playerLight = player.GetComponent<Invisiblilityscript> ().LightExposure ();
			if(playerLight > 0)
				DetectPlayer ();}

		else{
			audSnore.mute = false;
			threaten = false;}

	   
		if (awake && threaten)
			alert.mute = false;
		else {
			alert.mute = true;
			alert.Play ();
		}

		if (shot) {
			audSnore.mute = true;
			Shot ();
			GetComponentInChildren<ParticleSystem> ().Play ();

			shot=false;
			//Destroy=true;
			//Destroy(this.gameObject);
		}
		//DetectCollision (player);
		//*aniController.SetBool ("Timer", time);*//
	}



	void Shot(){
		audShot.mute = false;
		audShot.Play();
		aniController.SetBool ("Fire",true);
		//*shotAnim.SetFloat("Speed_f",0.3f);*//
		//accessAnimator("ShotAni_0");
		//aniController.SetFloat ("Speed",0.3f);
		/*shotAnim.Play ("Shot");*/
		player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.MELEE);
		//player.GetComponent<PlayerController> ().lives -= 1;
		//if (player.GetComponent<PlayerController> ().lives < 0)
		//player.GetComponent<PlayerController> ().lives = 3;
		DestroyObject (player);

	}

	void DetectPlayer(){
		float distance;
		int a = 0;
		distance= Vector3.Distance (player.transform.position, this.transform.position);

		/**awakeAnim.SetFloat("Speed_f",0.0f);**/
		if (distance < alertDistance) {
			threaten = true;
			//approachAlert.GetComponent<Text> ().text = "Alert!!";
		} else {
			threaten = false;
			//approachAlert.GetComponent<Text> ().text = " ";
		}

		if (threaten && distance < shotDistance) {
			shot=true;
		}
	
	}



	void OnTriggerEnter2D(Collider2D coll)
	{   Vector3 tempG = transform.position;
		Vector3 tempP = player.transform.position;
		playerLight = player.GetComponent<Invisiblilityscript> ().LightExposure ();
 	    if (coll.CompareTag ("Player") && playerLight <= 0)
			myColliders.enabled = false;

		else if (coll.CompareTag ("Player") && playerLight > 0) {

			if (player.transform.position.x>=this.transform.position.x)
				tempP.x = tempG.x + 2.0f;

			else
				tempP.x = tempG.x - 2.0f;
			player.transform.position=tempP;
		}
	}









}
