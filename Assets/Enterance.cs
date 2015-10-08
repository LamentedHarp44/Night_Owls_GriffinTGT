using UnityEngine;
using System.Collections;

public class Enterance : MonoBehaviour {

	public Sprite closed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			GameObject.FindGameObjectWithTag ("Boss").GetComponent<BigTimmy> ().inArena = true;
			GameObject.FindGameObjectWithTag ("Boss Door").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.FindGameObjectWithTag ("Boss Door").GetComponent<SpriteRenderer> ().sprite = closed;
		}
	}
}
