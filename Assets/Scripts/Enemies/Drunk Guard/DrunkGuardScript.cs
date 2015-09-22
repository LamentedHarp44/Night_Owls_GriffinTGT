using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrunkGuardScript : MonoBehaviour {
	GameObject player;
	GameObject approachAlert;
	public GameObject drunkenGuard;
	bool awake;
	bool threaten;
	float drunkTime;
	float awakeTime;
	float alertDistance;
	float shotDistance;
	public AudioSource audSnore;
	public AudioSource audShot;
	public AudioSource alert;

	/**public Animator drunkenAnim;
	public Animator shotAnim;
	public Animator awakeAnim;**/

	Animator aniController;
	float animaterTimer;
	bool idle;
	public float dt;

	/*Player.GetComponent<Invisiblilityscript> ().VisCheck();
	 */

	// Use this for initialization
	void Start () {
		aniController=drunkenGuard.GetComponent<Animator>();
		player=GameObject.FindGameObjectWithTag("Player");
		approachAlert=GameObject.FindWithTag ("approachAlert");
		approachAlert.GetComponent<Text> ().text = "";
		awake=false;
		threaten=false;
		drunkTime = 5.0f;
		awakeTime = 50.0f;
		alertDistance = 5.0f;
		shotDistance = 2.0f;
		//InvokeRepeating("ChangeState",5.0f,awakeTime);
		animaterTimer = 0;
		audSnore.mute = false;
		idle = false;
		audSnore.Play ();

		//aniController.SetFloat ("Speed",0.3f);
		//*awakeAnim.SetFloat("Speed_f",0.3f);*//
	}
	
	// Update is called once per frame
	void Update () {

		animaterTimer += Time.deltaTime;
	

		//Sleeping to awake
		if (animaterTimer > 5 && !awake && !idle) {
			aniController.SetFloat ("Timer", animaterTimer);
			aniController.SetBool ("awake", awake);
			awake = true;
			audSnore.mute = true;
	
		}
		//Awake to sleeping
		else if (animaterTimer > 5 && awake && !idle) {
			aniController.SetFloat ("Timer", animaterTimer);
			aniController.SetBool ("awake", awake);
			idle = true;
			audSnore.mute = false;

		} else if (animaterTimer > 5 && awake && idle) {
			aniController.SetFloat ("Timer", animaterTimer);
			aniController.SetBool ("awake", awake);
			aniController.SetBool ("idle", idle);
			animaterTimer = 0;
			awake = false;
		}
		else if (animaterTimer > 10 ){
			animaterTimer = 0;
			awake = false;
		}
		//*DetectPlayer ();*//
		//*aniController.SetBool ("Timer", time);*//
	}

	void ChangeState(){
		if (animaterTimer == 0)
			animaterTimer = 6.0f;
		else
			animaterTimer=0.0f;
		awake = !awake;
		if (awake || alert || threaten) {
			audSnore.mute = true;
			aniController.SetFloat ("Timer", animaterTimer);
			//*awakeAnim.SetFloat("Speed_f",0.0f);*//
			//aniController.SetFloat ("Speed",0.0f);
			/**accessAnimator("StandAni_0");*/
			//accessAnimator("StandAni_0");
			//aniController.SetFloat ("Speed",0.3f);

		}
		else {
			audSnore.mute = false;
			//*awakeAnim.SetFloat("Speed_f",0.3f);*//
		

			//aniController.SetFloat ("Speed",0.3f);
			//aniController.SetBool ("Timer", animaterTimer);
		}
	}

	void Shot(){
		audShot.mute = false;
		audShot.Play();
		alert.mute=true;
		//*shotAnim.SetFloat("Speed_f",0.3f);*//
		//accessAnimator("ShotAni_0");
		aniController.SetFloat ("Speed",0.3f);
		/*shotAnim.Play ("Shot");*/
		player.GetComponent<PlayerController> ().lives -= 1;
		if (player.GetComponent<PlayerController> ().lives < 0)
			player.GetComponent<PlayerController> ().lives = 3;

	}

	void DetectPlayer(){
		int playerLight = player.GetComponent<Invisiblilityscript> ().LightExposure ();
		if (!awake || playerLight==0 ) {
			threaten=false;
			return;
		}

		float distance;
		distance= Vector2.Distance (player.transform.position, this.transform.position);

		/**awakeAnim.SetFloat("Speed_f",0.0f);**/
		if (distance < alertDistance) {
			threaten = true;
			alert.mute=false;
			alert.Play ();
			alert.mute=true;
			approachAlert.GetComponent<Text> ().text = "Alert!!";
		} else {
			threaten = false;
			approachAlert.GetComponent<Text> ().text = "";
		}
		if (threaten && distance < shotDistance)
			Shot ();
	
	}











}
