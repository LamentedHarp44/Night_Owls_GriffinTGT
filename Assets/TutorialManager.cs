using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponentInChildren<Invisiblilityscript> ().SetExposure (2);
		GetComponentInChildren<DogBehavior> ().leash = 2;

		GetComponentInChildren<containerscript> ().SetUp (Random.Range (1.0f, 3.0f), (int)Random.Range (1.0f, 3.0f) * 50);

		GetComponentInChildren<WindowFadingLightScript> ().lightLvl = 2;
		GetComponentInChildren<WindowDirectLightScript> ().lightLvl = 3;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
