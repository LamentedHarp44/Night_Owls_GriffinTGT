using UnityEngine;
using System.Collections;

public class LightMeterHUDScript : MonoBehaviour {
	public int lightLevel; 
	public Texture inputTexture;
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		lightLevel=player.GetComponent<PlayerController>().lightLevel;
	}
	
	// Update is called once per frame
	void Update () {
		lightLevel=player.GetComponent<PlayerController>().lightLevel;
	}


	void OnGUI()
	{
		for (int i=0; i<lightLevel; i++) {
			GUI.DrawTexture (new Rect (350, 50, 40*lightLevel,20 ), inputTexture);
		}
	}
}
