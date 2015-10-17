using UnityEngine;
using System.Collections;

public class LiveHUDScript : MonoBehaviour {
	//string texture = "InvisibleMan.png";
	public Texture inputTexture;
	public int lives; 
	public GameObject player;


	void Start () {
	
		/*inputTexture = (Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath(texture, typeof(Texture2D));*/
	//	lives=player.GetComponent<PlayerController>().lives;
	
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player == null)
			player = GameObject.FindWithTag ("Player");

		lives=player.GetComponent<PlayerController>().lives;

	}

	void OnGUI()
	{
		if (!GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().gPause)
		if (!GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().gPause)
		for (int i=0; i<lives; i++) {
			GUI.DrawTexture (new Rect (i * 40 + 45, 45, 40, 33), inputTexture);
		}
	}


}
