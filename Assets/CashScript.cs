using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CashScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag ("Player");


		GetComponent<Text>().text = player.GetComponent<PlayerController>().loot.ToString();


	}
}
