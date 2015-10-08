using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GrappleGunUGButtonBehavior : MonoBehaviour {

	public Button[] GGButtons;
	Button VAButton;
	Button GAButton;
	Button BAButton;
	bool VAPressed = false;
	bool GAPressed = false;
	bool BAPressed = false;
	GameObject player;
	int playersLoot = 0;


	// Use this for initialization
	void Start () 
	{

		VAButton = GameObject.FindWithTag ("VAButton").GetComponent<Button>();
		GAButton = GameObject.FindWithTag ("GAButton").GetComponent<Button>();
		BAButton = GameObject.FindWithTag ("BAButton").GetComponent<Button>();

		GGButtons = new Button[3];
		GGButtons [0] = VAButton;
		GGButtons [1] = GAButton;
		GGButtons [2] = BAButton;

		GGButtons [0].interactable = false;
		GGButtons [1].interactable = false;
		GGButtons [2].interactable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindWithTag ("Player");

		playersLoot = player.GetComponent<PlayerController> ().loot;


		if (playersLoot >= 200 && VAPressed == false) 
		{
			GGButtons [0].interactable = true;
		} 
		else if (playersLoot >= 200 && VAPressed == true && GAPressed == false) 
		{
			GGButtons [1].interactable = true;
		} 
		else if (playersLoot >= 200 && GAPressed == true && BAPressed == false) 
		{
			GGButtons [2].interactable = true;
		} 
		else 
		{
			GGButtons[0].interactable = false;
			GGButtons[1].interactable = false;
			GGButtons[2].interactable = false;
		}

	}

	public void OnVAButtonPress()
	{
		if (VAPressed == false && playersLoot >= 200) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			VAPressed = true;
			GGButtons [0].interactable = false;
			ColorBlock temp = GGButtons [0].colors;
			temp.disabledColor = Color.green;
			GGButtons [0].colors = temp;
		}
	}

	public void OnGAButtonPress()
	{
		if (GAPressed == false && VAPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			GAPressed = true;
			GGButtons [1].interactable = false;
			ColorBlock temp = GGButtons [1].colors;
			temp.disabledColor = Color.green;
			GGButtons [1].colors = temp;
		}
	}

	public void OnBAButtonPress()
	{
		if (BAPressed == false && GAPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			BAPressed = true;
			GGButtons [2].interactable = false;
			ColorBlock temp = GGButtons [2].colors;
			temp.disabledColor = Color.green;
			GGButtons [2].colors = temp;
		}
	}


}
