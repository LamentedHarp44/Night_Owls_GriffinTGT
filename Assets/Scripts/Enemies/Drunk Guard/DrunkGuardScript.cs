using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrunkGuardScript : MonoBehaviour {

	public float sleepTimer;
	public float awakeTimer;
	public float attackTimer;
	public float detRange;
	public bool sighted;
	public bool asleep;
	public GameObject player;
	public bool face;


	public void Update()
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (asleep)
		{
			sleepTimer -= Time.fixedDeltaTime;
			if (sleepTimer <= 0) {
				asleep = false;
				sleepTimer = 4.0f;
			}
		}
		else if (!asleep) 
		{
			awakeTimer -= Time.fixedDeltaTime;
			Detect();
			if(awakeTimer <= 0 && !sighted)
			{
				asleep = true;
				awakeTimer = 3.0f;
			}
			else if(sighted)
			{
				attackTimer -= Time.fixedDeltaTime;
				if(attackTimer <= 0 && sighted)
				{
					player.GetComponent<PlayerController>().PlayerDeath(TYPE_DEATH.RANGED);
				}
			}
		}
	}


	void Detect()
	{
		float tempRange = detRange * player.GetComponent<PlayerController> ().lightExpo;
		RaycastHit2D target;



		if (tempRange < 0)
			tempRange = 0;

		if (face) 
			target = Physics2D.Raycast ((Vector2)transform.position, Vector2.left, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);
		else
			target = Physics2D.Raycast ((Vector2)transform.position, Vector2.right, tempRange, Physics2D.DefaultRaycastLayers, -1.0f);
			
		if (target.collider != null && target.collider.gameObject.tag == "Player")
			sighted = true;
		else 
		{
			sighted = false;
			attackTimer = 1.0f;
		}

	
	}


}
