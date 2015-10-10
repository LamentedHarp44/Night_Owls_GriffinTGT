using UnityEngine;
using System.Collections;

public class LoadGameBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSave()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lives = PlayerPrefs.GetInt ("Lives");
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().loot = PlayerPrefs.GetInt ("Money");
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lastCompleted = (LVL_CMPLT)PlayerPrefs.GetInt ("Level");
		PlayerPrefs.SetInt ("VAPurchase", PlayerPrefs.GetInt ("SavedVAPurchase"));
		PlayerPrefs.SetInt ("GAPurchase", PlayerPrefs.GetInt ("SavedGAPurchase"));
		PlayerPrefs.SetInt ("BAPurchase", PlayerPrefs.GetInt ("SavedBAPurchase"));
		PlayerPrefs.SetInt ("CooldownReduction", PlayerPrefs.GetInt ("SavedCooldownReduction"));
		PlayerPrefs.SetInt ("DurationIncrease", PlayerPrefs.GetInt ("SavedDurationIncrease"));
		PlayerPrefs.SetInt ("TrueInvisible", PlayerPrefs.GetInt ("SavedTrueInvisible"));
		PlayerPrefs.SetInt ("UndetectedSearch", PlayerPrefs.GetInt ("SavedUndetectedSearch"));
		PlayerPrefs.SetInt ("LightExpo", PlayerPrefs.GetInt ("SavedLightExpo"));

		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Hub World";
		Application.LoadLevel("Loading Screen");
	}
}
