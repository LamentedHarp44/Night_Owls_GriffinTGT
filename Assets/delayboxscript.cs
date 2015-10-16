using UnityEngine;
using System.Collections;

public class delayboxscript : MonoBehaviour {

	public GameObject smashedCrate;
	public GameObject newCrate;
	public AudioClip clip;
	AudioSource SFXVolume;


	// Use this for initialization
	void Start () 
	{
		newCrate = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SFXVolume == null)
			SFXVolume = GameObject.FindWithTag ("CrateAudio").GetComponent<AudioSource> ();
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Floor") 
		{
			newCrate = Instantiate(smashedCrate);
			newCrate.transform.position = transform.position;
			//newCrate.GetComponent<AudioSource>().Play();//*****************************************
			SFXVolume.Play();
			Destroy(this.gameObject);

		}

	}





}
