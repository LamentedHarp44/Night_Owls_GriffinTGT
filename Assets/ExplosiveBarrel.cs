using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour {

	//  The barrel needs to know if it is falling.
	public bool freeFall, exploded;
	public Sprite openDoor;
	float deathTime = .70f;
	// Use this for initialization
	void Start () {
		freeFall = true;

		exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (exploded == true) 
		{
			deathTime -= Time.deltaTime;

			if (deathTime <= 0.0f)
			{
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Boss") && freeFall && !exploded) 
		{
			Explode ();
		} 
		else if (other.gameObject.CompareTag ("Floor") && freeFall) 
		{
			freeFall = false;
		} 
		else if (other.gameObject.CompareTag ("Player") && freeFall) 
		{
			freeFall = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("GrappleHook") && !freeFall && !exploded && other.gameObject.GetComponent<GrappleHookScript>().shot) 
		{
			Explode ();
		}
	}

	//  The barrel will play an exposion.
	void Explode()
	{
		GetComponent<ParticleSystem> ().Play ();

		if (Mathf.Abs (transform.position.x - GameObject.FindGameObjectWithTag ("Player").transform.position.x) < 2.0f &&
			Mathf.Abs (this.transform.position.y - GameObject.FindGameObjectWithTag ("Player").transform.position.y) < 2.0f) 
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().PlayerDeath (TYPE_DEATH.SWARM);

			GameObject.FindGameObjectWithTag("Boss").GetComponent<BigTimmy>().ResetTimmy();
			GameObject.FindGameObjectWithTag("Boss Door").GetComponent<BoxCollider2D>().enabled = false;
			GameObject.FindGameObjectWithTag("Boss Door").GetComponent<SpriteRenderer>().sprite = openDoor;
		}

		if (Mathf.Abs (transform.position.x - GameObject.FindGameObjectWithTag ("Boss").transform.position.x) < 3.0f &&
		    Mathf.Abs (this.transform.position.y - GameObject.FindGameObjectWithTag ("Boss").transform.position.y) < 5.0f)	
			GameObject.FindGameObjectWithTag("Boss").GetComponent<BigTimmy> ().TakeDamage ();

		exploded = true;
	}
}
