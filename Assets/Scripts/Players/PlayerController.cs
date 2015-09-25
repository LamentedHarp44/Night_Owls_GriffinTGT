using UnityEngine;
using System.Collections;

public enum TYPE_DEATH {MELEE = 0, RANGED, SWARM};
public enum LAD_MOVEMENT {DOWN, STAY, UP};
public enum LVL_CMPLT {TUTORIAL, LVL_ONE, LVL_TWO, LVL_THREE, LVL_FOUR, LVL_FIVE, LVL_SIX, LVL_SEVEN, LVL_EIGHT, LVL_NINE}

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public bool onLadder;
	public int loot;
	public GameObject usable;
	char upgrades;
	public int lightExpo;
	public Transform mainSpawn;
	public LVL_CMPLT lastCompleted = 0;

	public int lives;
	public int lightLevel;

	//Jump variables
	float jumpForce = 600f;
	public bool grounded;
	float jumpNumber = 0;

	int level;

	//  The us of a ladder involves locking x-axis movement
	//bool horizLock;
	//  and allowing the elevator to know whether the unit is moving up or down.
	public LAD_MOVEMENT ladMove = LAD_MOVEMENT.STAY;

	//variable for pausing the game
	public static bool gamePause = false; 
	public bool pauseMenuToggle=false;
	public GameObject pauseMenu;
	
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
		transform.position = mainSpawn.transform.position;
		lives = 3;
		lightLevel = 0;
		grounded = true;
		level = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GetComponentInChildren<GrappleHookScript>().shot == false)
			Movement ();

		if (Input.GetKey ("e"))
			Use ();
		//cooldownEffect
		else if (Input.GetKeyDown ("q")) {
			GetComponent<Invisiblilityscript> ().Invisibility ();
			//cooled=true;
			//Debug.Log("pressed");
			cooldown.GetComponent<CoolDownHud> ().coolDown ();
		}
		//cooldownEffect
		//else if (Input.GetKeyDown ("p") && cooled == false) {
			//cooled=true;
			//Debug.Log("pressed");
			//cooldown.GetComponent<CoolDownHud> ().coolDown ();
		//}

		if (jumpNumber == 0 && Input.GetKeyDown(KeyCode.Space) && grounded == true
		    && GetComponentInChildren<GrappleHookScript>().shot == false) 
		{
			jumpNumber = 1;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			grounded = false;
		}

		// call pause menu
		else if (Input.GetKeyDown (KeyCode.Escape)) {
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
		if (Input.GetKey ("a"))
			temp.x -= moveSpeed * Time.deltaTime;
		else if (Input.GetKey ("d"))
			temp.x += moveSpeed * Time.deltaTime;
		

		if (Input.GetKey("w"))
			ladMove = LAD_MOVEMENT.UP;
		else if (Input.GetKey("s"))
			ladMove = LAD_MOVEMENT.DOWN;

		else ladMove = LAD_MOVEMENT.STAY;


		transform.position = temp;
	}

	//  This one function will handle the multiple types of death possible to the player
	//  Parameters:		The function takes in a TYPE_DEATH and uses that to determine
	//					which actions to take.
	public void PlayerDeath(TYPE_DEATH method)
	{
		//if (method == TYPE_DEATH.MELEE)
		  //this.GetComponent<Invisiblilityscript> ().SetExposure (0);

		GetComponentInChildren<ParticleSystem> ().Play ();
		//GetComponent<Transform> ().position = new Vector3 (20.0f, 20.0f, 0.0f);
		transform.position = mainSpawn.transform.position;
		lives--;
		if (lives == 0) 
		{
			Destroy(this);
			Application.LoadLevel(level);
			lives = 3;
		}
	}

	void Use()
	{
		if (usable == null)
			return;

		if (usable.tag == "chest") 
		{
			if(usable.GetComponent<containerscript>().inUse() <= 0)
				loot += usable.GetComponent<containerscript>().Payout();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Floor")
			usable = col.gameObject;

		if (col.gameObject.tag == "Floor" || col.gameObject.tag == "chest") 
		{
			jumpNumber = 0;
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		usable = null;
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
}
