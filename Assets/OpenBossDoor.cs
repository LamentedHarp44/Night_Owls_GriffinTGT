using UnityEngine;
using System.Collections;

public class OpenBossDoor : MonoBehaviour {

	public Sprite open;


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
			GameObject.FindGameObjectWithTag ("Boss").GetComponent<BigTimmy> ().inArena = false;
			GameObject.FindGameObjectWithTag ("Boss Door").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("Boss Door").GetComponent<SpriteRenderer> ().sprite = open;
		}
	}
}
