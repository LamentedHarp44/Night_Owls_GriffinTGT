using UnityEngine;
using System.Collections;

public class ContinueGame : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (player == null)
			player = GameObject.FindWithTag ("Player");

	}

	public void Continue()
	{
		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Hub World";

		if(player.GetComponent<PlayerController>().lightExpoPurchased == false)
			player.GetComponent<PlayerController> ().lightExpo = 0;
		else
			player.GetComponent<PlayerController> ().lightExpo = -2;

		Application.LoadLevel ("Loading Screen");
	}
}
