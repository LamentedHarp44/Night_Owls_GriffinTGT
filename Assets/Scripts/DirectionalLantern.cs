using UnityEngine;
using System.Collections;

public class DirectionalLantern : MonoBehaviour {

	//  The lantern needs to attach to a unit
	public GameObject unit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (unit == null)
			unit = GameObject.FindGameObjectWithTag ("Player");


		if (unit != null)
			GetComponent<Transform>().position = unit.GetComponentInChildren<LanternAnchor>().Position();

		//Quaternion quat = new Quaternion ();
		//quat.Inverse(transform.rotation);
		
		if (unit.GetComponent<Transform> ().localScale.x > 0.0f && transform.rotation.y > 0.5f) 
		{
			transform.rotation = Quaternion.Inverse (transform.rotation);
		} 

		else if (unit.GetComponent<Transform> ().localScale.x < 0.0f && transform.rotation.y < 0.5f) 
		{
			transform.rotation = Quaternion.Inverse (transform.rotation);
		}
	}
}
