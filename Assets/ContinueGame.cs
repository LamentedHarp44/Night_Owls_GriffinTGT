using UnityEngine;
using System.Collections;

public class ContinueGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Continue()
	{
		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Hub World";

		Application.LoadLevel ("Loading Screen");
	}
}
