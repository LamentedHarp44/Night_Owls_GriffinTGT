using UnityEngine;
using System.Collections;

public class GrappleGunScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Aims the gun and hook towards the mouse position.
		if (GetComponentInChildren<GrappleHookScript> ().shot == false)
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 5.23f;
		
			Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;
		
			float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;

			if(angle > 0 && angle < 90)
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		}

	}


}
