using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewGameScript : MonoBehaviour {


	public AudioClip sound;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void LoadNewGame()
	{
		StartCoroutine (LoadScene ());
	}

	IEnumerator LoadScene()
	{
		GetComponent<AudioSource>().PlayOneShot(sound);
		PlayerPrefs.SetString("VAPressed", "false");
		PlayerPrefs.SetString("GAPressed", "false");
		PlayerPrefs.SetString("BAPressed", "false");
		PlayerPrefs.SetString("CRButtonPressed", "false");
		PlayerPrefs.SetString("DIButtonPressed", "false");
		PlayerPrefs.SetString("TrueIButtonPressed", "false");
		PlayerPrefs.SetString("CRButtonPressed2", "false");
		PlayerPrefs.SetString("DIButtonPressed2", "false");
		PlayerPrefs.SetString("UndetectedSButtonPressed", "false");
		PlayerPrefs.SetString("CRButtonPressed3", "false");
		PlayerPrefs.SetString("DIButtonPressed3", "false");
		PlayerPrefs.SetString("TransparencyButtonPressed", "false");
		yield return new WaitForSeconds (.3f);
		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl = "tutorial";
		Application.LoadLevel("Loading Screen");
	}
}
