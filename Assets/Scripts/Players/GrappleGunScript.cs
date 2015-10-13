using UnityEngine;
using System.Collections;

public class GrappleGunScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Pause") != null && !GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {

			//Aims the gun and hook towards the mouse position.
			//Need to fix scaling issue with gun following mouse cursor**********************************************************
			if (GetComponentInChildren<GrappleHookScript> ().shot == false) {

				Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
				Vector3 mousePos = Input.mousePosition - objectPos;

				float angle = 0;
				if (player.transform.localScale.x > 0)
					angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
				else
					angle = Mathf.Atan2 (mousePos.y, -mousePos.x) * Mathf.Rad2Deg;

				if (angle > -10 && angle < 90) {
					transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
				}

			}
		}
	}


}
