using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LadderBehavior : MonoBehaviour {

	//  The ladder will need to have capacity for multiple elevators
	//  at once.
	List<GameObject> elevators = new List<GameObject>();

	//  The ladder also needs to have a copy of an elevator to clone.
	public GameObject prefab;

	//  The ladder needs to be able to tell children who they belong to.
	//public GameObject currObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.CompareTag ("Untagged")) 
		{
			for (int i = 0; i < elevators.Count; ++i) {
				if (elevators [i].gameObject.GetComponent<ElevatorBehavior> ().user == coll.gameObject)
					return;
			}
			//  The temporary elevator will spawn at the unit's feet, and then
			//  be added to the elevators array.
			GameObject tempElevator;

			//  The elevator needs to be spawned at a very specific point
			//  X-value:		center of the ladder
			//  Y-value:		bottom of the player collision/unit
			//  Z-value:		0.0f
			Vector3 spawnPoint = new Vector3 (GetComponent<Transform> ().position.x,
		                                 coll.GetComponent<Transform> ().position.y,
		                                 0.0f);


			tempElevator = 
			Instantiate (prefab, spawnPoint, Quaternion.identity) as GameObject;

			tempElevator.GetComponent<ElevatorBehavior> ().parent = this.gameObject;
			tempElevator.GetComponent<ElevatorBehavior> ().user = coll.gameObject;

			elevators.Add (tempElevator);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{

			for (int i = 0; i <= elevators.Count; ++i) 
			{
				if (elevators [i].gameObject.GetComponent<ElevatorBehavior> ().user == coll.gameObject) {
					DestroyElevator (elevators [i]);
				}
			}
	}

	//  This function will delete an elevator that is no longer in use
	void DestroyElevator(GameObject elev)
	{
		Destroy (elev);
		elevators.Remove (elev);
	}
}
