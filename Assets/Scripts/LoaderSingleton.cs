using UnityEngine;
using System.Collections;

public class LoaderSingleton : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
		if (!GameObject.FindGameObjectWithTag ("Loader")) {
			//  Then instantiate one at the spawnpoint
			Instantiate (prefab);
		}
		
		else 
		{
			//  If there is a player,
			//  then put it at the spawn point.			
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
