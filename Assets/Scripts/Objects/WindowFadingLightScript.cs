using UnityEngine;
using System.Collections;

public class WindowFadingLightScript : MonoBehaviour {

	public GameObject player;
	public int lightLvl;
	
	// Use this for initialization
	void Start () {
		lightLvl = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
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
