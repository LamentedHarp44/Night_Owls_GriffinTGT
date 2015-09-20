using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEffectsScript : MonoBehaviour {

	public AudioSource soundEFX;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void SetSFXVolume(float volumeLvl)
	{
		soundEFX.volume = volumeLvl;
	}

}
