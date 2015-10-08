using UnityEngine;
using System.Collections;

public enum TYPE_DEATH {MELEE = 0, RANGED, SWARM, TRAP};
public enum LAD_MOVEMENT {DOWN, STAY, UP};
public enum LVL_CMPLT {TUTORIAL, LVL_ONE, LVL_TWO, LVL_THREE, LVL_FOUR, LVL_FIVE, LVL_SIX, LVL_SEVEN, LVL_EIGHT, LVL_NINE, NONE}

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public bool moving;
	public bool hiding;
	public bool onLadder;
	public int loot;
	public GameObject usable, timmy;
	GameObject hiddenDoor;
	char upgrades;
	public int lightExpo = 0;
	int lightExpoPurchaseTracker = 0;
	public bool lightExpoPurchased = false;
	Transform mainSpawn;
	public LVL_CMPLT lastCompleted = LVL_CMPLT.NONE;
	public int ratCount;
	public int lives;
	//public int lightLevel;
	
	//  Little Timmy needs to know how many times Griffin has pushed him down
	public int numPush;
	//Jump variables
	float jumpForce = 600f;
	public bool grounded;
	float jumpNumber = 0;

	bool flip;
	bool facingRight;

	int level;

	AudioSource SFXVolume;

	//  The us of a ladder involves locking x-axis movement
	//bool horizLock;
	//  and allowing the elevator to know whether the unit is moving up or down.
	public LAD_MOVEMENT ladMove = LAD_MOVEMENT.STAY;

	//variable for pausing the game
	public static bool gamePause = false; 
	public bool pauseMenuToggle=false;
	public GameObject pauseMenu;

	//variable for plugMenu the game
	public bool plugMenuToggle=false;
	public GameObject plugMenu;
	
	//variable for cooling down
	public bool cooled;
	//public float cooldown;
	public GameObject cooldown; 


	// Use this for initialization
	void Start () 
	{
		moveSpeed = 5.0f;
		onLadder = false;
		usable = null;
		mainSpawn = GameObject.FindWithTag ("Main Spawn").GetComponent<Transform>();
		transform.position = mainSpawn.transform.position;
		lives = 3;
		//lightLevel = 0;
		grounded = true;
		level = Application.loadedLevel;
		moving = false;
		hiding = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//If Transparency upgrade purchased, permanently decrease lightExpo by 2; 
		lightExpoPurchaseTracker = PlayerPrefs.GetInt ("LightExpo");
		if (lightExpoPurchaseTracker == 1) 
		{
			lightExpo = -2;
			lightExpoPurchased = true;
			PlayerPrefs.SetInt("LightExpo", 0);
		}



		if (SFXVolume == null)
			SFXVolume = GameObject.FindGameObjectWithTag ("Player Audio").GetComponentInChildren<AudioSource> ();

		//Telling the player script it is hiding in a hidden door.
		if(hiddenDoor != null)
			hiding = hiddenDoor.GetComponent<HiddenDoorScript> ().hiding;


		if (mainSpawn == null) 
		{
			mainSpawn = GameObject.FindGameObjectWithTag ("Main Spawn").transform;
			transform.position = mainSpawn.transform.position;
		}
		if(GetComponentInChildren<GrappleHookScript>().shot == false)
			Movement ();

		if (Input.GetKey ("e"))
			Use ();
		//cooldownEffect
		else if (Input.GetKeyDown ("q")) {
			GetComponent<Invisiblilityscript> ().Invisibility ();
			//cooled=true;
			//Debug.Log("pressed");
			//cooldown.GetComponent<CoolDownHud> ().coolDown ();
		}

		//call plug menu
		else if (Input.GetKeyDown ("z")) {
			plugMenuToggle=!plugMenuToggle;
			
			
			if (plugMenuToggle){
				plugMenu.GetComponent<CanvasGroup>().alpha=1;
				plugMenu.GetComponent<CanvasGroup>().interactable=true;
				
				
			}
			else{
				plugMenu.GetComponent<CanvasGroup>().alpha=0;
				plugMenu.GetComponent<CanvasGroup>().interactable=false;
			}
		}

		//Jumping
		if (jumpNumber == 0 && Input.GetKeyDown(KeyCode.Space) && grounded == true)
		    //&& GetComponentInChildren<GrappleHookScript>().shot == false) 
		{
			jumpNumber = 1;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			grounded = false;
			GetComponentInChildren<GrappleHookScript>().shot = false;
		}

		// call pause menu
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseMenuToggle=!pauseMenuToggle;
			
			
			if (pauseMenuToggle){
				pauseMenu.GetComponent<CanvasGroup>().alpha=1;
				pauseMenu.GetComponent<CanvasGroup>().interactable=true;
				
				
			}
			else{
				pauseMenu.GetComponent<CanvasGroup>().alpha=0;
				pauseMenu.GetComponent<CanvasGroup>().interactable=false;
			}
		}


		if (gamePause)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;


		DontDestroyOnLoad (this);

	}


	//  Fixed Update is called every two frames and should be used for any Rigid
	//  Body or Physics functionality
	void FixedUpdate()
	{

	}

	void Movement()
	{
		//Movement
		Vector3 temp = transform.position;

		//  If there is anything limiting the player's horizontal movement
		//		(i.e. being on a ladder)
		//  lock their horizontal controls
		if (Input.GetKey ("a")) {
			temp.x -= moveSpeed * Time.fixedDeltaTime;

			facingRight = false;
			Flip (facingRight);
			moving = true;
		} else if (Input.GetKey ("d")) {
			temp.x += moveSpeed * Time.fixedDeltaTime;

			facingRight = true;
			Flip (facingRight);
			moving = true;
		} else
			moving = false;

		if (Input.GetKey("w"))
			ladMove = LAD_MOVEMENT.UP;
		else if (Input.GetKey("s"))
			ladMove = LAD_MOVEMENT.DOWN;

		else ladMove = LAD_MOVEMENT.STAY;


		transform.position = temp;
	}

	//Fliping the player's scale.x to face moving direction.
	void Flip(bool facing_right)
	{
		if (facing_right == true) 
		{
			Vector3 scale = transform.localScale;
			scale.x = 1;
			transform.localScale = scale;
		} 
		else 
		{
			Vector3 scale = transform.localScale;
			scale.x = -1;
			transform.localScale = scale;
		}
	}

	//  This one function will handle the multiple types of death possible to the player
	//  Parameters:		The function takes in a TYPE_DEATH and uses that to determine
	//					which actions to take.
	public void PlayerDeath(TYPE_DEATH method)
	{
		//if (method == TYPE_DEATH.MELEE)
		  //this.GetComponent<Invisiblilityscript> ().SetExposure (0);


		if (method == TYPE_DEATH.TRAP)
			GetComponentInChildren<ParticleSystem> ().startColor = Color.green;
		else
			GetComponentInChildren<ParticleSystem> ().startColor = Color.red;

		GetComponentInChildren<ParticleSystem> ().Play ();
		if (SFXVolume != null)
			SFXVolume.Play ();

		//GetComponent<Transform> ().position = new Vector3 (20.0f, 20.0f, 0.0f);
		lives--;
		StartCoroutine (PlayerDeadRespawn());
		if (lives == 0) 
		{
			//Destroy(this);
			Application.LoadLevel(level);
			lives = 3;
		}
	}

	//The delay for player respawn so it plays blood splatter.
	public IEnumerator PlayerDeadRespawn()
	{

		yield return new WaitForSeconds (.5f);
		if(hiddenDoor != null)
			hiddenDoor.GetComponent<HiddenDoorScript> ().DeactivateHiding ();

		transform.position = mainSpawn.transform.position;
	}

	void Use()
	{
		if (usable != null) {
			if (usable.tag == "chest") {
				if (usable.GetComponent<containerscript> ().inUse () <= 0)
					loot += usable.GetComponent<containerscript> ().Payout ();
			}
		}

		if (timmy != null) 
		{
			int temp = 0;
			temp += timmy.GetComponent<LittleTimmy>().KnockDown();
			if (temp > 0)
			{
				loot += temp;
				
				numPush += 1;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Floor")
			usable = col.gameObject;

		if (col.gameObject.tag == "Floor" || col.gameObject.tag == "chest" || col.gameObject.tag == "Crate") 
		{
			jumpNumber = 0;
			grounded = true;
		}


	}

	void OnCollisionExit2D(Collision2D col)
	{
		usable = null;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Little Timmy"))
			timmy = other.gameObject;

		if (other.CompareTag ("HiddenDoor")) 
		{
			hiddenDoor = other.gameObject;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "ADRange" && GetComponentInChildren<GrappleHookScript> ().verticalAnchorStruck == true) 
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}


	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Little Timmy"))
			timmy = null;

		if (other.CompareTag ("HiddenDoor"))
			hiddenDoor = null;
	}


	//  This function is a setter for the horizMove bool
	//  Parameters:			bool, F = canMove, T = can'tMove
	//public void LockHorizontalMovement(bool b)
	//{
	//	horizLock = b;
	//}

	//  This function is what all units who can move vertically
	//  on a ladder will have to inform the elevator of what movement
	//  to make.
	public LAD_MOVEMENT GetLadMovement()
	{
		return ladMove;
	}

	public LVL_CMPLT GetCompletedLevel()
	{
		return lastCompleted;
	}


	//Shop Menu Upgrade Functions**********************************************************************************************************
	public void PurchaseVerticalAttachment()
	{
		//PlayerPrefs.SetInt ("VAPurchase", 1);
	}

	public void PurchaseGrabAttachment()
	{
		//PlayerPrefs.SetInt ("GAPurchase", 1);
	}

	public void PurchaseBladeAttachment()
	{
		//PlayerPrefs.SetInt ("BAPurchase", 1);
	}

	public void PurchaseCooldownReduction()
	{
		//PlayerPrefs.SetInt ("CooldownReduction", 1);
	}

	public void PurchaseDurationIncrease()
	{
		//PlayerPrefs.SetInt ("DurationIncrease", 1);
	}

	public void PurchaseTrueInvisible()
	{
		//PlayerPrefs.SetInt ("TrueInvisible", 1);
	}

	public void PurchaseUndetectedSearch()
	{

	}

	public void PurchaseTransparency()
	{
		//PlayerPrefs.SetInt ("LightExpo", 1);
	}

}
