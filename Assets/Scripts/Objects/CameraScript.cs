using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.position = new Vector3 (player.position.x, player.position.y, player.position.z - 1);
	}
}
