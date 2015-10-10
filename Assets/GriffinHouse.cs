using UnityEngine;
using System.Collections;

public class GriffinHouse : MonoBehaviour {

	public string nxtLvl = "TimmyFight";
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>().lvl = nxtLvl;

			Application.LoadLevel("Loading Screen");
		}
	}
}
