using UnityEngine;
using System.Collections;


public class LevelDoorsBehavior : MonoBehaviour {
	//  This is which level the door will take the player to
	public string toLvl;

	//  This is the condition that needs to be met for the door to open
	public LVL_CMPLT condition;

	bool open;
	GameObject player = null;

	// Use this for initialization
	void Start () {
		open = false;
	}

	// Update is called once per frame
	void Update () {
		if (condition == FindObjectOfType<PlayerController> ().GetCompletedLevel () && !open) {
			//open the door
			open = true;
			GetComponentInChildren<AudioSource>().Play ();
			this.GetComponent<Animator>().SetTrigger("OpenUp");
		}

		if (player != null) {
			if (player.GetComponent<PlayerController>().GetLadMovement() == LAD_MOVEMENT.UP)
			{
				GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>().lvl = toLvl;
				Application.LoadLevel("Loading Screen");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (open) {
			if (col.CompareTag("Player"))
				player = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject == player) {
			player = null;
		}
	}
}
