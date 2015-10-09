using UnityEngine;
using System.Collections;

public class SaveButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveGame()
	{
		PlayerController temp = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();

		PlayerPrefs.SetInt ("Level", (int)temp.GetCompletedLevel ());
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
	}
}
