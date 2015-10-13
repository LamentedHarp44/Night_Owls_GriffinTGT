using UnityEngine;
using System.Collections;

public class SnoreBehavior : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (Mathf.Abs (player.transform.position.x - this.transform.position.x) < 10.0f
			&& Mathf.Abs (player.transform.position.y - this.transform.position.y) < 3.0f)
			GetComponent<AudioSource> ().enabled = true;
		else
			GetComponent<AudioSource> ().enabled = false;
	}
}
