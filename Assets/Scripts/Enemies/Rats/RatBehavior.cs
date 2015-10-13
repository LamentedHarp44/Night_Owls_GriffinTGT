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
	public float particle;
	public Color starter;
	public AudioClip clip;
	public float colideTimer;
	public int livesCounter;
	public int tempLives;
	// Use this for initialization
	void Start () 
	{

		tempLives = 3;
		colideTimer = 2.0f;
		clip = GetComponent<AudioSource> ().clip;
		starter = GetComponentInChildren<ParticleSystem> ().startColor;
		home = transform.position;
		moveSpeed = 2;
		facing = true;
		leash = 4;
		atkTimer = 1.5f;
		attacking = false;
		ground = true;
		particle = 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (!GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {

			livesCounter = player.GetComponent<PlayerController> ().lives;
		
			if (tempLives != livesCounter) {
				tempLives = livesCounter;
				transform.position = home;
				player.GetComponent<PlayerController> ().ratCount = 0;
				player.GetComponent<PlayerController> ().moveSpeed = 5.0f;
			}




			//Launcher ();

			if (GetComponent<CircleCollider2D> ().enabled == false) {
				colideTimer -= Time.fixedDeltaTime;

				if (colideTimer <= 0) {
					colideTimer = 2.0f;
					GetComponent<CircleCollider2D> ().enabled = true;
				}
			}



			if (moveDist <= 0)
				moveDist = Random.Range (0.0f, leash);

			if (ground)
			if (attacking)
				Attack ();
			else
				Movement ();


			if (attacking) {
				particle -= Time.fixedDeltaTime;

				if (particle <= 0) {
					particle = 2.0f;
					GetComponentInChildren<ParticleSystem> ().startColor = starter;
					GetComponentInChildren<ParticleSystem> ().Play ();
				}

			}



			if (player.GetComponent<PlayerController> ().ratCount >= 5 && player.GetComponent<Invisiblilityscript> ().LightExposure () < 4) {
				GetComponentInChildren<ParticleSystem> ().startColor = Color.red;
				killTimer -= Time.fixedDeltaTime;

				if (killTimer <= 0) {
					player.GetComponent<PlayerController> ().ratCount = 0;
					player.GetComponent<PlayerController> ().moveSpeed = 5.0f;
					attacking = false;
					this.transform.position = home;
					player.GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);
				}
			} else {
				killTimer = 3.0f;
			}
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
				temp2.x *= -1;
			} 
			else if ((moveDist <= 0 && !facing) || home.x - leash > transform.position.x) {
				facing = true;
				temp2.x = Mathf.Abs(temp2.x);
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
		GetComponent<AudioSource> ().Play ();


			if (player.GetComponent<Invisiblilityscript> ().LightExposure () < 4) {
				Vector3 temp = transform.position;
				temp.x = player.transform.position.x + Random.Range (-0.1f, 0.1f);
				temp.y = player.transform.position.y + Random.Range (0.1f, 0.3f);
				transform.position = temp;
			} else {
				atkTimer -= Time.fixedDeltaTime;
				if (atkTimer <= 0) {
					attacking = false;
				Vector3 temp = transform.position;
				temp.x = player.transform.position.x - .2f;
				temp.y = player.transform.position.y + .2f;
				GetComponent<CircleCollider2D>().enabled = false;
				GetComponentInChildren<BoxCollider2D>().enabled = true;
				GetComponent<Rigidbody2D>().gravityScale = 1;
				player.GetComponent<PlayerController> ().moveSpeed += .5f;
				player.GetComponent<PlayerController> ().ratCount -= 1;
				transform.position = temp;
				} else {
					Vector3 temp = transform.position;
					temp.x = player.transform.position.x + Random.Range (-0.1f, 0.1f);
					temp.y = player.transform.position.y + Random.Range (.1f, 0.3f);
					transform.position = temp;
				}
			}

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			GetComponent<AudioSource>().PlayOneShot(clip);
			GetComponentInChildren<BoxCollider2D> ().enabled = false;
			attacking = true;
			atkTimer = 1.5f;
			player.GetComponent<PlayerController>().moveSpeed -= .5f;
			player.GetComponent<PlayerController>().ratCount += 1;
			GetComponent<Rigidbody2D>().gravityScale = 0;

		}
	}

	public void Launcher()
	{
		//test code
	//	if (Input.GetKeyDown (KeyCode.Backspace)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2000f, 1000f));

			ground = false;
	//	}
	}


}
