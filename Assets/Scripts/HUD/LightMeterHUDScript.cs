using UnityEngine;
using System.Collections;

public class LightMeterHUDScript : MonoBehaviour {
	public int lightLevel; 
	public Texture inputTexture;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
		//lightLevel=player.GetComponent<PlayerController>().lightLevel;
	//	lightLevel = player.GetComponent<Invisiblilityscript> ().LightExposure ();
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null)
			player = GameObject.FindWithTag ("Player");
		//lightLevel=player.GetComponent<PlayerController>().lightLevel;
		lightLevel = player.GetComponent<Invisiblilityscript> ().LightExposure ();
	}


	void OnGUI()
	{
		if (!GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().gPause)
		for (int i=0; i<lightLevel; i++) {
			GUI.DrawTexture (new Rect (350, 50, 40*lightLevel,20 ), inputTexture);
		}
	}
}
