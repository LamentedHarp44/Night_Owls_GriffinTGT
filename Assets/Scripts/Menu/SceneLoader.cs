using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
	public string lvl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (this.gameObject);
	}

	public void DoStuff()
	{
		Application.LoadLevelAsync (lvl);
	}
}
