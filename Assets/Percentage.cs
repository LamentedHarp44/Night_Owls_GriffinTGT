using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Percentage : MonoBehaviour {
	public int lvl;
	// Use this for initialization
	void Start () {
		lvl = GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().lvl;

		GameObject.FindGameObjectWithTag ("Loader").GetComponent<SceneLoader> ().DoStuff ();
	}
	
	// Update is called once per frame
	void Update () {
		int percent = (int)(Application.GetStreamProgressForLevel (lvl) * 100);
		GetComponent<Text> ().text = percent.ToString () + "%";
	}
}
