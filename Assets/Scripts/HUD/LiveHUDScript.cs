using UnityEngine;
using System.Collections;

public class LiveHUDScript : MonoBehaviour {
	string texture = "InvisibleMan.png";
	public Texture inputTexture;
	public int lives; 
	public GameObject player;


	void Start () {
		player = GameObject.FindWithTag ("Player");
		/*inputTexture = (Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath(texture, typeof(Texture2D));*/
		lives=player.GetComponent<PlayerController>().lives;
	
		
	}
	
	// Update is called once per frame
	void Update () {
		lives=player.GetComponent<PlayerController>().lives;

	}

	void OnGUI()
	{
		for (int i=0; i<lives; i++) {
			GUI.DrawTexture (new Rect (i * 90 + 50, 50, 81, 66), inputTexture);
		}
	}


}
