using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ReturnToMain()
	{
		Application.LoadLevel ("Main Menu");
	}
}
