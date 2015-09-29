using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	float dt = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dt < 0.5f)
			GetComponent<Text> ().text = "Loading .";
		else if (dt >= 0.5f && dt < 1.0f)
			GetComponent<Text> ().text = "Loading . .";
		else
			GetComponent<Text> ().text = "Loading . . .";

		if (dt > 1.5f)
			dt = 0.0f;

		dt += Time.deltaTime;
	}
}
