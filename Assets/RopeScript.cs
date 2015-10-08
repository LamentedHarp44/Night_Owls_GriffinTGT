using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Hook") 
		{
			GetComponentInParent<Rigidbody2D>().gravityScale = 1;
			Destroy(this.gameObject);

		}


	}






}
