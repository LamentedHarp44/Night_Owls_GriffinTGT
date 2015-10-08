using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {
	
	public GameObject prefab, leftSpawn, leftTrigger, rightSpawn, rightTrigger;

	// true = right
	bool spawnSide;

	// Use this for initialization
	void Start () {
		spawnSide = true;
	}
	
	// Update is called once per frame
	void Update () {
		//  If there isn't a barrel in the scene, create one.
		if (GameObject.FindGameObjectWithTag ("Barrel") == null) 
		{
			if (spawnSide)
			{
				Instantiate(prefab, rightSpawn.transform.position, Quaternion.identity);
				spawnSide = false;
				
				// Activate the trigger of the apropriate launcher
				rightTrigger.GetComponent<BarrelLaunch>().ready = true;
			}

			else if (!spawnSide)
			{
				Instantiate(prefab, leftSpawn.transform.position, Quaternion.identity);
				spawnSide = true;
				
				// Activate the trigger of the apropriate launcher
				leftTrigger.GetComponent<BarrelLaunch>().ready = true;
			}
		}

	}

	public void BarrelLaunch()
	{
		if (!spawnSide)
			GameObject.FindGameObjectWithTag ("Barrel").GetComponent<Rigidbody2D> ().AddForce (new Vector2(-500.0f, 250.0f));
		else if (spawnSide)
			GameObject.FindGameObjectWithTag ("Barrel").GetComponent<Rigidbody2D> ().AddForce (new Vector2(500.0f, 250.0f));

		GameObject.FindGameObjectWithTag ("Barrel").GetComponent<ExplosiveBarrel> ().freeFall = true;
	}
}
