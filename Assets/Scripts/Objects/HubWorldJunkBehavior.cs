using UnityEngine;
using System.Collections;

public class HubWorldJunkBehavior : MonoBehaviour {

	//  The stuff disapears after level 3
	LVL_CMPLT condition;

	// Use this for initialization
	void Start () {
		condition = LVL_CMPLT.LVL_THREE;
	}
	
	// Update is called once per frame
	void Update () {
		if (condition <= FindObjectOfType<PlayerController> ().GetCompletedLevel ())
			Destroy (this.gameObject);
	}
}
