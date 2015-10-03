using UnityEngine;
using System.Collections;

public class WindowFadingLightScript : MonoBehaviour {

	GameObject player;
	public int lightLvl;

	
	// Use this for initialization
	void Start () {
		lightLvl = 2;
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			player.GetComponent<PlayerController>().lightExpo += lightLvl;
			player.GetComponent<Invisiblilityscript>().SetExposure(player.GetComponent<Invisiblilityscript>().LightExposure() + lightLvl);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			player.GetComponent<Invisiblilityscript>().SetExposure(player.GetComponent<Invisiblilityscript>().LightExposure() - lightLvl);
			player.GetComponent<PlayerController>().lightExpo -= lightLvl;
		}
	}
}
