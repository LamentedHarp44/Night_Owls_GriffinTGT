using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSFXSliderScript : MonoBehaviour{//, IDragHandler {

	public Slider volumeSlider;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<AudioSource> ().volume = volumeSlider.value;
		volumeSlider.value = PlayerPrefs.GetFloat ("SFXVolume");
	}


	public void SetVolume()
	{
		GetComponent<AudioSource> ().Play ();
		PlayerPrefs.SetFloat("SFXVolume", volumeSlider.value);
	}


	/*
	public void OnDrag(PointerEventData eventData)		
	{
		GetComponent<AudioSource> ().Play ();
		PlayerPrefs.SetFloat ("SFXVolume", volumeSlider.value);
	} 
	*/

}
