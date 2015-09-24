using UnityEngine;
using System.Collections;

public class GrappleHookScript : MonoBehaviour {


	public float shootSpeed = 500;
	public float shootDistance = 5f;
	public bool shot = false;
	bool collided = false;

	public GameObject grappleGun;
	public GameObject startPos;
	public GameObject player;
	float distanceShot = 0;
	public float timer = 0;
	Vector2 position;
	Vector2 direction;


	// Use this for initialization
	void Start () 
	{
		transform.position = startPos.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Sets the hook's fire range.
		GetComponent<DistanceJoint2D> ().distance = shootDistance;

		//Setting hook to start position.
		if (shot == false) 
		{
			transform.position = startPos.transform.position;
			collided = false;
			timer = 0;
		}


		//Shooting the gun
		if (Input.GetKeyDown (KeyCode.Mouse0) && shot == false && player.GetComponent<PlayerController>().grounded == true) 
		{
			//Taking the cursor position and firing the grapple hook in that position at a constant speed.
//			position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//			position = Camera.main.ScreenToWorldPoint(position);
//			Vector2 temp = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
//			direction = position - temp;
//			direction = direction.normalized;

			GetComponent<Rigidbody2D>().AddForce(transform.right * 500);

			//Rotating the hook so it faces the direction shot
			//Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( position.y, position.x )* Mathf.Rad2Deg);
			//transform.rotation = rotation;

			shot = true;
		}

		//Temporary until more solid solution.
		//If the hook is fired and hits nothing set back to starting position.
		//----------------
		if(shot == true && collided == false)
			timer += Time.deltaTime;

		if (timer >= .75f && shot == true && collided == false) 
		{
			shot = false;
		}
		//----------------

	

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		//If the hook hits a wall, set player's gravity to zero and move him toward the hook and stop the hook.
		if (other.tag == "Wall" && shot == true) 
		{
			player.GetComponent<Rigidbody2D>().gravityScale = 0;
			player.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			collided = true;
		}
		
		//Once the player moves towards the hook and collides with it, set player's gravity and hook position back.
		if (other.tag == "Player") 
		{
			shot = false;
			player.GetComponent<Rigidbody2D>().gravityScale = 1;
		}



	}




}
