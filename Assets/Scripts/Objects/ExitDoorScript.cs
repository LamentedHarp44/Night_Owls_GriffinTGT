using UnityEngine;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {

	Animator anim;
	public bool Lock = true;
	public AudioClip sound;
	float playCount = 0f;
	public string nxtlvl = "Hub World";
	public LVL_CMPLT currLvl;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("Locked", Lock);
		
		if (Lock == false && playCount == 0) 
		{
			GetComponent<AudioSource> ().PlayOneShot (sound);
			playCount = 1f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && Lock == false) 
		{
			if(other.GetComponent<PlayerController>().lightExpoPurchased == false)
				other.GetComponent<PlayerController> ().lightExpo = 0;
			else
				other.GetComponent<PlayerController> ().lightExpo = -2;
			other.GetComponent<PlayerController>().lastCompleted = currLvl;
			GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>().lvl = nxtlvl;
			Application.LoadLevel("Loading Screen");
		}
	}

}
