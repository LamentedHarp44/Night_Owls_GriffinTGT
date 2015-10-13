using UnityEngine;
using System.Collections;

public class GrappleHookScript : MonoBehaviour {


	public float shootSpeed = 500;
	//public float shootDistance = 5f;
	public bool shot = false;
	bool collided = false;
	float playerReachedHook;

	public GameObject grappleGun;
	public GameObject startPos;
	public GameObject player;
	GameObject grabCrate;
	//float distanceShot = 0;
	public float timer = 0;
	Vector2 position;
	Vector2 direction;

	//Vertical Attachment Variables
	public bool verticalAnchorStruck = false;
	public bool VAPurchased = false;
	int VAPurchaseTracker = 0;
	//Grab Attachment Variables.
	public bool GAPurchased = false;
	int GAPurchaseTracker = 0;
	//Blade Attachment Variables.
	public bool BAPurchased = false;
	int BAPurchaseTracker = 0;

	// Use this for initialization
	void Start () 
	{
		transform.position = startPos.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (grabCrate == null)
			grabCrate = GameObject.FindWithTag ("GrabCrate");

		//Checking if upgrade has been purchased in the shop menu, if so then apply grapple functionality.
		//----------------------------------------------------
		VAPurchaseTracker = PlayerPrefs.GetInt ("VAPurchase");
		if (VAPurchaseTracker == 1) {
			VAPurchased = true;
			PlayerPrefs.SetInt("VAPurchase", 0);
		}
		GAPurchaseTracker = PlayerPrefs.GetInt ("GAPurchase");
		if (GAPurchaseTracker == 1) {
			GAPurchased = true;
			PlayerPrefs.SetInt("GAPurchase", 0);
		}
		BAPurchaseTracker = PlayerPrefs.GetInt ("BAPurchase");
		if (BAPurchaseTracker == 1) {
			BAPurchased = true;
			PlayerPrefs.SetInt("BAPurchase", 0);
		}
		//----------------------------------------------------


		//Setting hook to start position.
		if (shot == false) 
		{
			transform.position = startPos.transform.position;
			collided = false;
			timer = 0;
			verticalAnchorStruck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D>().gravityScale = 1;
		}


		//Shooting the gun
		if (Input.GetKeyDown (KeyCode.Mouse0) && shot == false && player.GetComponent<PlayerController> ().grounded == true) 
		{
			if(player.transform.localScale.x > 0)
			{
				GetComponent<Rigidbody2D> ().AddForce (transform.right * 500);
			}
			else
			{
				Vector3 temp = transform.right;
				temp.y = transform.right.y * -1;

				GetComponent<Rigidbody2D> ().AddForce (temp * -500);
			}

			shot = true;
		} 
		else if (Input.GetKeyDown (KeyCode.Mouse0) && shot == true)//Canceling the shot (Helps with bad grapple usage).
		{
			shot = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D>().gravityScale = 1;
		}


		//Vertical attachment behavior if the upgrade is purchased.
		if (shot == true && verticalAnchorStruck == true && VAPurchased == true)
		{
			//Raising player and lowering hook(hook is a child and moves with parent so needed to offset position).
			if(Input.GetKey(KeyCode.W))
			{
				Vector3 temp = player.transform.position;
				temp.y += .08f;
				player.transform.position = temp;
				Vector3 temp1 = transform.position;
				temp1.y -= .08f;
				transform.position = temp1;
			}
			else if(Input.GetKey(KeyCode.S))//Lowering player and raising hook
			{
				Vector3 temp = player.transform.position;
				temp.y -= .08f;
				player.transform.position = temp;
				Vector3 temp1 = transform.position;
				temp1.y += .08f;
				transform.position = temp1;
			}
			else if (Input.GetKeyDown (KeyCode.Mouse0))//Detaches the vertical attach mode.
			{
				shot = false;
				player.GetComponent<Rigidbody2D>().gravityScale = 1;
			}
		}

		//Grab Attachment functionality. If the hook hits the crate, lock its position to the crates.
		if (grabCrate != null) 
		{
			if (grabCrate.GetComponent<GrabCrateScript> ().dragToPlayer == true) 
			{
				transform.position = grabCrate.transform.position;
			}
		}

		//If the hook is fired and hits nothing set back to starting position.
		if(shot == true && collided == false)
			timer += Time.deltaTime;

		if (timer >= .90f && shot == true && collided == false) 
		{
			shot = false;
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		//If the hook hits a wall, set player's gravity to zero and move him toward the hook and stop the hook.
		if (other.tag == "Wall" && shot == true) 
		{
			player.GetComponent<Rigidbody2D>().gravityScale = 0;

			if(player.transform.localScale.x > 0)
				player.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
			else
			{
				Vector3 temp = transform.right;
				temp.y = transform.right.y * -1;
				player.GetComponent<Rigidbody2D>().AddForce(temp * -500);
			}

			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			collided = true;
		}
		
		//Once the player moves towards the hook and collides with it, set player's gravity and hook position back.
		if (other.tag == "Player") 
		{
			shot = false;
			player.GetComponent<Rigidbody2D>().gravityScale = 1;
		}

		//Initiating vertical attachment behavior.
		if (other.tag == "VerticalAnchor" && shot == true && VAPurchased == true) 
		{
			verticalAnchorStruck = true;
			collided = true;
			player.GetComponent<Rigidbody2D>().gravityScale = 0;

			if(player.transform.localScale.x > 0)
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
			else
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);

			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		if (other.tag == "Floor" || other.tag == "chest") 
		{
			shot = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		if (other.tag == "GrabCrate" && shot == true && GAPurchased == true) 
		{
			collided = true;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

	}


}
