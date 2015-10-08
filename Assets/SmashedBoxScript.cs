using UnityEngine;
using System.Collections;

public class SmashedBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "boss") 
		{
			col.gameObject.GetComponent<DeathWall>().slowed = true;

		}


	}




}
