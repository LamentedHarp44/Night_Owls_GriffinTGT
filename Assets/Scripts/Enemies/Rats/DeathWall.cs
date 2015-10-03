using UnityEngine;
using System.Collections;

public class DeathWall : MonoBehaviour {
	public float moveSpeed;
	public float shotTime;
	GameObject player;
	public GameObject rat;
	public GameObject shot;


	// Use this for initialization
	void Start () {
		shotTime = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		shotTime -= Time.fixedDeltaTime;
		if (shotTime <= 0) 
		{

			shot = Instantiate(rat);
			shot.transform.position = transform.position;
			shot.GetComponent<RatBehavior>().Launcher();
			shotTime = 15 - (1 * Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position));
			shot = null;
		}
	}
}
