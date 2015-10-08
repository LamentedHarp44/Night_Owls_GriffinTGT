using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopMenuMoneyDisplayScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindWithTag ("Player");

		int temp = player.GetComponent<PlayerController> ().loot;
		GetComponent<Text> ().text = temp.ToString();
	
	}
}
