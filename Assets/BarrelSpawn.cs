using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {

	//  The explosive barrel prefab.
	public GameObject barrelPrefab;

	//  The location of the left/right spawn.
	public GameObject leftSpawn, rightSpawn, lLauncher, rLauncher;

	//  Which side should the barrel spawn on?
	//			True = left, False = right
	bool spawnSide;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag ("Barrel") == null) 
		{
			spawnSide = !spawnSide;

			if (spawnSide)
			{
				Instantiate(barrelPrefab,  leftSpawn.transform.position, Quaternion.identity);
				lLauncher.GetComponent<BarrelLaunch>().ready = true;
			}
			else 
			{
				Instantiate(barrelPrefab, rightSpawn.transform.position, Quaternion.identity);
				rLauncher.GetComponent<BarrelLaunch>().ready = true;
			}
		}
	}

	public void BarrelLaunch()
	{
		if (spawnSide) 
		{
			GameObject.FindGameObjectWithTag ("Barrel").GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50.0f, 200.0f));
			GameObject.FindGameObjectWithTag("Barrel").GetComponent<ExplosiveBarrel>().freeFall = true;
			lLauncher.GetComponent<BarrelLaunch>().ready = true;
		} 
		else 
		{
			GameObject.FindGameObjectWithTag("Barrel").GetComponent<Rigidbody2D>().AddForce(new Vector2 (-500.0f, 200.0f));
			GameObject.FindGameObjectWithTag("Barrel").GetComponent<ExplosiveBarrel>().freeFall = true;
			rLauncher.GetComponent<BarrelLaunch>().ready =  true;
		}
	}
}
