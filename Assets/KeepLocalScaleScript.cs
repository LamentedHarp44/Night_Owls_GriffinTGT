using UnityEngine;
using System.Collections;

public class KeepLocalScaleScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindWithTag ("Player");

		Vector3 temp = player.transform.position;
		temp.y  = temp.y + 3;
		transform.position = temp;
		//transform.localScale = transform.localScale;
	}
}
