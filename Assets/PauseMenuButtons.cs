using UnityEngine;
using System.Collections;

public class PauseMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResumeClick()
	{
		GetComponentInParent<PauseMenu> ().ResumeGame ();
	}

	public void SaveAndQuitClick()
	{
		PlayerController temp = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		
		PlayerPrefs.SetInt ("Level", (int)temp.GetCompletedLevel());
		PlayerPrefs.SetInt ("Money", temp.loot);
		PlayerPrefs.SetInt ("Lives", temp.lives);
		PlayerPrefs.SetInt ("SavedVAPurchase", PlayerPrefs.GetInt ("VAPurchase"));
		PlayerPrefs.SetInt ("SavedGAPurchase", PlayerPrefs.GetInt ("GAPurchase"));
		PlayerPrefs.SetInt ("SavedBAPurchase", PlayerPrefs.GetInt ("BAPurchase"));
		PlayerPrefs.SetInt ("SavedCooldownReduction", PlayerPrefs.GetInt ("CooldownReduction"));
		PlayerPrefs.SetInt ("SavedDurationIncrease", PlayerPrefs.GetInt ("DurationIncrease"));
		PlayerPrefs.SetInt ("SavedTrueInvisible", PlayerPrefs.GetInt ("TrueInvisible"));
		PlayerPrefs.SetInt ("SavedUndetectedSearch", PlayerPrefs.GetInt ("UndetectedSearch"));
		PlayerPrefs.SetInt ("SavedLightExpo", PlayerPrefs.GetInt ("LightExpo"));
		
		
		PlayerPrefs.Save ();

		Destroy (GameObject.FindGameObjectWithTag ("Player"));

		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Main Menu";
		Application.LoadLevel ("Loading Screen");
	}

	public void QuitClick()
	{
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		
		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Main Menu";
		Application.LoadLevel ("Loading Screen");
	}
}
