using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	//  The prefab of the player if there isn't one in the scene
	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
		// if there isn't a player made
		if (!GameObject.FindGameObjectWithTag ("Player")) {
			//  Then instantiate one at the spawnpoint
			Instantiate (prefab, 
			             GameObject.FindGameObjectWithTag ("Main Spawn").transform.position, Quaternion.identity);

		}

		else 
		{
			//  If there is a player,
			//  then put it at the spawn point.
			GameObject.FindGameObjectWithTag("Player").transform.position 
				= GameObject.FindGameObjectWithTag("Main Spawn").transform.position;

			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
