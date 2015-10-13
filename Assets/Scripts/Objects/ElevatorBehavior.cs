using UnityEngine;
using System.Collections;

public class ElevatorBehavior : MonoBehaviour {

	//  This object needs to know it's parent
	public GameObject parent;
	//  This object needs to know it's user
	public GameObject user;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Pause") != null && !GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {

			if (user != null) {
				if (user.CompareTag ("Player")) {
					if (user.GetComponent<PlayerController> ().GetLadMovement () == LAD_MOVEMENT.DOWN) {
						GetComponent<Transform> ().position += new Vector3 (0.0f, -1.5f, 0.0f) * Time.fixedDeltaTime;
					} else if (user.GetComponent<PlayerController> ().GetLadMovement () == LAD_MOVEMENT.UP) {
						GetComponent<Transform> ().position += new Vector3 (0.0f, 1.5f, 0.0f) * Time.fixedDeltaTime;
					}
				}

				if (user.CompareTag ("PatrollingGuard")) {
					if (user.GetComponent<GuardBehavior> ().GetLadMovement () == LAD_MOVEMENT.DOWN) {
						GetComponent<Transform> ().position += new Vector3 (0.0f, -1.5f, 0.0f) * Time.fixedDeltaTime;
					} else if (user.GetComponent<GuardBehavior> ().GetLadMovement () == LAD_MOVEMENT.UP) {
						GetComponent<Transform> ().position += new Vector3 (0.0f, 1.5f, 0.0f) * Time.fixedDeltaTime;
					}
				}
			}

			//if (parent != null && user != null) {
			//	if (Mathf.Abs(this.GetComponent<Transform>().position.x - user.GetComponent<Transform>().position.x) > parent.GetComponent<Transform>().localScale.x)
			//		Destroy (this.gameObject);
			//}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		user = coll.gameObject;

		//user.GetComponent<PlayerController> ().LockHorizontalMovement (true);
	}


}
