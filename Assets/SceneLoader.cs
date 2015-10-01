using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
	public int lvl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (gameObject);
	}

	public void DoStuff()
	{
		Application.LoadLevelAsync (lvl);
	}
}
