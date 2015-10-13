using UnityEngine;
using System.Collections;

public class QuitToMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToMain()
	{
		Destroy(GameObject.FindGameObjectWithTag("Player"));

		PlayerPrefs.SetInt("VAPurchase", 0);

		PlayerPrefs.SetInt("GAPurchase", 0);

		PlayerPrefs.SetInt("BAPurchase", 0);

		PlayerPrefs.SetInt ("CooldownReduction", 0);

		PlayerPrefs.SetInt ("DurationIncrease", 0);

		PlayerPrefs.SetInt ("TrueInvisible", 0);

		PlayerPrefs.SetInt ("UndetectedSearch", 0);

		PlayerPrefs.SetInt ("LightExpo", 0);

		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "Main Menu";
		Application.LoadLevel ("Loading Screen");
	}
}
