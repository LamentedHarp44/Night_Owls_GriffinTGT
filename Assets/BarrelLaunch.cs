using UnityEngine;
using System.Collections;

public class BarrelLaunch : MonoBehaviour {

	public GameObject launcher;
	public Sprite activeSprite, inactiveSprite;
	public bool ready, close;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ready == true) 
		{
			GetComponent<SpriteRenderer> ().sprite = activeSprite;

			if (close && Input.GetKeyDown (KeyCode.E)) {
				launcher.GetComponent<BarrelSpawn> ().BarrelLaunch ();
				ready = false;
			}
		} 
		else
			GetComponent<SpriteRenderer> ().sprite = activeSprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			close = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			close = false;
		}
	}
}
