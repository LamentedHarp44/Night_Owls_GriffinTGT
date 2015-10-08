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
		else 
		{
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

	
	}

	public void OnCRButtonPress()
	{
		if (CRButtonPressed == false && playersLoot >= 100) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			CRButtonPressed = true;
			IButtons [0].interactable = false;
			ColorBlock temp = IButtons [0].colors;
			temp.disabledColor = Color.green;
			IButtons [0].colors = temp;
		}
	}

	public void OnDIButtonPress()
	{
		if (DIButtonPressed == false && CRButtonPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			DIButtonPressed = true;
			IButtons [1].interactable = false;
			ColorBlock temp = IButtons [1].colors;
			temp.disabledColor = Color.green;
			IButtons [1].colors = temp;
		}
	}

	public void OnTrueIButtonPress()
	{
		if (TrueIButtonPressed == false && DIButtonPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			TrueIButtonPressed = true;
			IButtons [2].interactable = false;
			ColorBlock temp = IButtons [2].colors;
			temp.disabledColor = Color.green;
			IButtons [2].colors = temp;
		}
	}

	public void OnCRButtonPress2()
	{
		if (CRButtonPressed2 == false && TrueIButtonPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			CRButtonPressed2 = true;
			IButtons [3].interactable = false;
			ColorBlock temp = IButtons [3].colors;
			temp.disabledColor = Color.green;
			IButtons [3].colors = temp;
		}
	}

	public void OnDIButtonPress2()
	{
		if (DIButtonPressed2 == false && CRButtonPressed2 == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			DIButtonPressed2 = true;
			IButtons [4].interactable = false;
			ColorBlock temp = IButtons [4].colors;
			temp.disabledColor = Color.green;
			IButtons [4].colors = temp;
		}
	}

	public void OnUndetectedSButtonPress()
	{
		if (UndetectedSButtonPressed == false && DIButtonPressed2 == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			UndetectedSButtonPressed = true;
			IButtons [5].interactable = false;
			ColorBlock temp = IButtons [5].colors;
			temp.disabledColor = Color.green;
			IButtons [5].colors = temp;
		}
	}

	public void OnCRButtonPress3()
	{
		if (CRButtonPressed3 == false && UndetectedSButtonPressed == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			CRButtonPressed3 = true;
			IButtons [6].interactable = false;
			ColorBlock temp = IButtons [6].colors;
			temp.disabledColor = Color.green;
			IButtons [6].colors = temp;
		}
	}

	public void OnDIButtonPress3()
	{
		if (DIButtonPressed3 == false && CRButtonPressed3 == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 100;
			DIButtonPressed3 = true;
			IButtons [7].interactable = false;
			ColorBlock temp = IButtons [7].colors;
			temp.disabledColor = Color.green;
			IButtons [7].colors = temp;
		}
	}

	public void OnTransparencyButtonPress()
	{
		if (TransparencyButtonPressed == false && DIButtonPressed3 == true) 
		{
			player.GetComponent<PlayerController> ().loot -= 200;
			TransparencyButtonPressed = true;
			IButtons [8].interactable = false;
			ColorBlock temp = IButtons [8].colors;
			temp.disabledColor = Color.green;
			IButtons [8].colors = temp;
		}
	}

}
