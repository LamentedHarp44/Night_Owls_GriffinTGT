using UnityEngine;
using System.Collections;

public class GrappleHookScript : MonoBehaviour {


	public float shootSpeed = 15;
	public float shootDistance = 10f;
	bool shot = false;
	bool collided = false;

	public GameObject grappleGun;
	public GameObject startPos;
	float distanceShot = 0;
	Vector2 position;

	// Use this for initialization
	void Start () 
	{
		transform.position = startPos.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (shot == false) 
		{
			transform.position = startPos.transform.position;
		}

		if (Input.GetKeyDown (KeyCode.Mouse0) && shot == false) 
		{
			position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			position = Camera.main.ScreenToWorldPoint(position);
			Vector2 temp = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
			Vector2 direction = position - temp;
			direction = direction.normalized;
			GetComponent<Rigidbody2D>().AddForce(direction * 500);

			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( position.y, position.x ) * Mathf.Rad2Deg);
			transform.rotation = rotation;
			//GetComponent<Rigidbody2D>().velocity = position * shootSpeed;
			shot = true;
		}



	}






}
