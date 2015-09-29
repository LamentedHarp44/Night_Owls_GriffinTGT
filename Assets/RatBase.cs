using UnityEngine;
using System.Collections;

public class RatBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Floor") {
			GetComponentInParent<RatBehavior> ().ground = true;
			GetComponentInParent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		} else if (col.gameObject.tag == "Player")
			GetComponentInParent<RatBehavior> ().Attack ();
	}



}
