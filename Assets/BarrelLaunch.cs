using UnityEngine;
using System.Collections;

public class BarrelLaunch : MonoBehaviour {

	public GameObject launcher;

	public bool ready, close;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ready == true) {
			if (close && Input.GetKeyDown(KeyCode.E))
			{
				launcher.GetComponent<BarrelSpawn>().BarrelLaunch();
			}
		}
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
