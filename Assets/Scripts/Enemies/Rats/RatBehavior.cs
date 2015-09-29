using UnityEngine;
using System.Collections;

public class RatBehavior : MonoBehaviour {
	public float killTimer;
	public bool attacking;
	public float atkTimer;
	public int moveSpeed;
	public bool facing; // left false, right true
	public Vector3 home;
	public float leash;
	public float moveDist;
	public GameObject player;
	public bool ground;
	// Use this for initialization
	void Start () {
		home = transform.position;
		moveSpeed = 2;
		facing = true;
		leash = 4;
		atkTimer = 1.5f;
		attacking = false;
		ground = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (moveDist <= 0)
			moveDist = Random.Range (0.0f, leash);

		if(ground)
			if (attacking)
				Attack ();
			else
				Movement ();




		if (player.GetComponent<PlayerController> ().ratCount >= 5 && player.GetComponent<Invisiblilityscript> ().LightExposure() < 4) 
		{
			killTimer -= Time.fixedDeltaTime;

			if (killTimer <= 0) 
			{
				player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);
			}
		} 
		else
		{
			killTimer = 3.0f;
		}
	}


	void Movement()
	{
		if (ground) 
		{
			Vector3 temp = transform.position;
			Vector3 temp2 = transform.localScale;
			float tempDist = moveSpeed * Time.fixedDeltaTime;

			moveDist -= tempDist;

			if ((moveDist <= 0 && facing) || home.x + leash < transform.position.x) {
				facing = false;

			} 
			else if ((moveDist <= 0 && !facing) || home.x - leash > transform.position.x) {
				facing = true;
			}


			if (facing)
				temp.x += tempDist;
			else
				temp.x -= tempDist;

			transform.position = temp;
			transform.localScale = temp2;
		}
	}
	public void Attack()
	{
		if (player.GetComponent<Invisiblilityscript> ().LightExposure () < 4) 
		{
			Vector3 temp = transform.position;
			temp.x = player.transform.position.x + Random.Range (-0.1f, 0.1f);
			temp.y = player.transform.position.y + Random.Range (-0.1f, 0.1f);
			transform.position = temp;
		}
		else
		{
			atkTimer -= Time.fixedDeltaTime;
			if(atkTimer <= 0)
			{
				attacking = false;
				Destroy(this.gameObject);
				player.GetComponent<PlayerController>().moveSpeed += .5f;
				player.GetComponent<PlayerController>().ratCount -= 1;
			}
			else
			{
				Vector3 temp = transform.position;
				temp.x = player.transform.position.x + Random.Range (-0.1f, 0.1f);
				temp.y = player.transform.position.y + Random.Range (-.1f, 0.1f);
				transform.position = temp;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			GetComponentInChildren<BoxCollider2D> ().enabled = false;
			attacking = true;
			atkTimer = 1.5f;
			player.GetComponent<PlayerController>().moveSpeed -= .5f;
			player.GetComponent<PlayerController>().ratCount += 1;

		}
	}

	public void Launcher()
	{
		//test code
		//if (Input.GetKeyDown (KeyCode.Backspace)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1000f, 1000f));

			ground = false;
		//}
	}


}
