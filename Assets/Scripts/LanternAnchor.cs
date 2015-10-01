using UnityEngine;
using System.Collections;

public class LanternAnchor : MonoBehaviour {

	//  The position
	Vector3 position;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		position = new Vector3(transform.position.x, transform.position.y, -0.1f);
	}

	public Vector3 Position()
	{
		return position;
	}
}
