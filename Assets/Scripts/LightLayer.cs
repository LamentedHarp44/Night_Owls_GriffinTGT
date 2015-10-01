using UnityEngine;
using System.Collections;

public class LightLayer : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			col.GetComponent<PlayerController>().lightExpo += 1;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			col.GetComponent<PlayerController>().lightExpo -= 1;
		}
	}
}
