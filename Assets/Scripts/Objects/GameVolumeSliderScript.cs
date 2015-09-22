using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameVolumeSliderScript : MonoBehaviour//, IBeginDragHandler, IEndDragHandler 
{

	public Slider volumeSlider;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		volumeSlider.value = PlayerPrefs.GetFloat ("Volume");
		GetComponent<AudioSource> ().volume = volumeSlider.value;
	}


	public void SetVolume()
	{
		PlayerPrefs.SetFloat ("Volume", volumeSlider.value);
	}

//	public void OnBeginDrag(PointerEventData eventData)
//	{
//		GetComponent<AudioSource> ().Play ();
//	}
//
//	public void OnEndDrag(PointerEventData eventData)
//	{
//		GetComponent<AudioSource> ().Stop ();
//	}

}
