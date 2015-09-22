using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSFXSliderScript : MonoBehaviour, IDragHandler {

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

	public void OnDrag(PointerEventData eventData)		
	{
		if(volumeSlider.value == .1f || volumeSlider.value == .3f || volumeSlider.value == .5f || volumeSlider.value == .7f 
		   || volumeSlider.value == .9f)
			GetComponent<AudioSource> ().Play ();
		PlayerPrefs.SetFloat ("SFXVolume", volumeSlider.value);
	} 
	

}
