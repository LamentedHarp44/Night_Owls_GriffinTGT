using UnityEngine;
using System.Collections;

public class HubWorldJunkBehavior : MonoBehaviour {

	//  The stuff disapears after level 3
	int condition;

	// Use this for initialization
	void Start () {
		condition = (int)LVL_CMPLT.LVL_THREE;
	}
	
	// Update is called once per frame
	void Update () {
		if (condition <= FindObjectOfType<PlayerController> ().GetCompletedLevel ()  && FindObjectOfType<PlayerController>().GetCompletedLevel() != (int)LVL_CMPLT.NONE)
			Destroy (this.gameObject);
	}
}
