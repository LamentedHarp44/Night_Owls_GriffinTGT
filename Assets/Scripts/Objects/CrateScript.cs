using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {

	public Transform ropeHook;
	public bool moveUp;
	public bool moveDown;

	// Use this for initialization
	void Start () 
	{
		moveUp = true;
		moveDown = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = ropeHook.position;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "CraneTop") 
		{
			moveUp = false;
		}

		if (other.tag == "Floor") 
		{
			moveDown = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "CraneTop") 
		{
			moveUp = true;
		}

		if (other.tag == "Floor") 
		{
			moveDown = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Floor") 
		{
			moveDown = false;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Floor") 
		{
			moveDown = true;
		}
	}

}
