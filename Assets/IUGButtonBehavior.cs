using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IUGButtonBehavior : MonoBehaviour {

	public Button[] IButtons;
	Button CRButton;
	Button DIButton;
	Button TrueIButton;
	Button CRButton2;
	Button DIButton2;
	Button UndetectedSButton;
	Button CRButton3;
	Button DIButton3;
	Button TransparencyButton;

	bool CRButtonPressed = false;
	bool DIButtonPressed = false;
	bool TrueIButtonPressed = false;
	bool CRButtonPressed2 = false;
	bool DIButtonPressed2 = false;
	bool UndetectedSButtonPressed = false;
	bool CRButtonPressed3 = false;
	bool DIButtonPressed3 = false;
	bool TransparencyButtonPressed = false;

	GameObject player;
	int playersLoot = 0;

	// Use this for initialization
	void Start () 
	{
		CRButton = GameObject.FindWithTag ("CRButton").GetComponent<Button> ();
		DIButton = GameObject.FindWithTag ("DIButton").GetComponent<Button> ();
		TrueIButton = GameObject.FindWithTag ("TrueIButton").GetComponent<Button> ();
		CRButton2 = GameObject.FindWithTag ("CRButton2").GetComponent<Button> ();
		DIButton2 = GameObject.FindWithTag ("DIButton2").GetComponent<Button> ();
		UndetectedSButton = GameObject.FindWithTag ("UndetectedSButton").GetComponent<Button> ();
		CRButton3 = GameObject.FindWithTag ("CRButton3").GetComponent<Button> ();
		DIButton3 = GameObject.FindWithTag ("DIButton3").GetComponent<Button> ();
		TransparencyButton = GameObject.FindWithTag ("TransparencyButton").GetComponent<Button> ();

		IButtons = new Button[9];
		IButtons [0] = CRButton;
		IButtons [1] = DIButton;
		IButtons [2] = TrueIButton;
		IButtons [3] = CRButton2;
		IButtons [4] = DIButton2;
		IButtons [5] = UndetectedSButton;
		IButtons [6] = CRButton3;
		IButtons [7] = DIButton3;
		IButtons [8] = TransparencyButton;

		IButtons [0].interactable = false;
		IButtons [1].interactable = false;
		IButtons [2].interactable = false;
		IButtons [3].interactable = false;
		IButtons [4].interactable = false;
		IButtons [5].interactable = false;
		IButtons [6].interactable = false;
		IButtons [7].interactable = false;
		IButtons [8].interactable = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
			player = GameObject.FindWithTag ("Player");

		playersLoot = player.GetComponent<PlayerController> ().loot;


		if (playersLoot >= 100 && CRButtonPressed == false)
			IButtons [0].interactable = true;
		else if (playersLoot >= 100 && CRButtonPressed == true && DIButtonPressed == false)
			IButtons [1].interactable = true;
		else if (playersLoot >= 200 && DIButtonPressed == true && TrueIButtonPressed == false)
			IButtons [2].interactable = true;
		else if (playersLoot >= 100 && TrueIButtonPressed == true && CRButtonPressed2 == false)
			IButtons [3].interactable = true;
		else if (playersLoot >= 100 && CRButtonPressed2 == true && DIButtonPressed2 == false)
			IButtons [4].interactable = true;
		else if (playersLoot >= 200 && DIButtonPressed2 == true && UndetectedSButtonPressed == false)
			IButtons [5].interactable = true;
		else if (playersLoot >= 100 && UndetectedSButtonPressed == true && CRButtonPressed3 == false)
			IButtons [6].interactable = true;
		else if (playersLoot >= 100 && CRButtonPressed3 == true && DIButtonPressed3 == false)
			IButtons [7].interactable = true;
		else if (playersLoot >= 200 && DIButtonPressed3 == true && TransparencyButtonPressed == false)
			IButtons [8].interactable = true;

		

		



	
	}
}
