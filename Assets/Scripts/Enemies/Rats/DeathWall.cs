using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathWall : MonoBehaviour {
	public float moveSpeed;
	public float shotTime;
	GameObject player;
	public GameObject rat;
	public GameObject shot;
	public float delayTimer;
	public bool slowed;
	public GameObject cannon;
	Vector3 home;
	public List<GameObject> ratSpawn;
	public int livesCounter;
	public int tempLives;
	// Use this for initialization
	void Start () 
	{
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		livesCounter = player.GetComponent<PlayerController> ().lives;
		tempLives = livesCounter;
		home = transform.position;
		slowed = false;
		delayTimer = 2.0f;
		shotTime = 2.0f;
		moveSpeed = 5.1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");


		livesCounter = player.GetComponent<PlayerController> ().lives;

		if (tempLives != livesCounter) 
		{
			tempLives = livesCounter;

			for (int i = 0; i < ratSpawn.Count; i++)
				Destroy (ratSpawn [i]);
			moveSpeed = 5.1f;
			
			transform.position = home;
			player.GetComponent<PlayerController> ().ratCount = 0;
			player.GetComponent<PlayerController> ().moveSpeed = 5.0f;
		}

		if (slowed) 
		{
			delayTimer -= Time.fixedDeltaTime;
			if(delayTimer <= 0)
			{
				slowed = false;
				delayTimer = 2.0f;
				moveSpeed = 5.1f;
			}
		}




		Vector3 temp = transform.position;

		temp.x += moveSpeed * Time.fixedDeltaTime;

		transform.position = temp;



		shotTime -= Time.fixedDeltaTime;
		if (shotTime <= 0) 
		{

			shot = Instantiate(rat);

			shot.transform.position = cannon.transform.position;
			shot.GetComponent<RatBehavior>().Launcher();


			if(Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position) < 20)
				shotTime = 5;
			else if(Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position) < 40)
				shotTime = 3;
			else
				shotTime = 1;

			ratSpawn.Add(shot);

			shot = null;



		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);


			for (int i = 0; i < ratSpawn.Count; i++)
				Destroy (ratSpawn [i]);
			moveSpeed = 5.1f;

			transform.position = home;
			player.GetComponent<PlayerController> ().ratCount = 0;
			player.GetComponent<PlayerController> ().moveSpeed = 5.0f;
		}
		else if (col.gameObject.tag == "Stop")
			moveSpeed = 0; 
		else if (col.gameObject.tag != "Floor" && col.gameObject.tag != "Ladder") 
		{
			if (col.gameObject.tag == "obst") {
				moveSpeed = 1.1f;
				slowed = true;
			}
			Destroy (col.gameObject);
		} 
	}



}
