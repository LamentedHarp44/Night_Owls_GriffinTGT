using UnityEngine;
using System.Collections;

public class containerscript : MonoBehaviour {


	public float normDelay;
	public float delay;
	public int value;
	GameObject loot;
	public Sprite opened;
	public AudioClip pick;
	public AudioClip open;
	public AudioClip hit;
	bool is_playing;
	bool is_open = false;
	// Use this for initialization
	public void SetUp () 
	{
		delay = 0;
	}
	
	// Update is called once per frame
	void Update()
	{

		if (GameObject.FindGameObjectWithTag("Pause") != null && !GameObject.FindGameObjectWithTag ("Pause").GetComponent<PauseMenu> ().gPause) {

		

		if (value == 0 && !is_open)
			value = Random.Range (1, 3) * 50;
			}
	}

	public float inUse () 
	{
		if (!is_playing) 
		{
			GetComponent<AudioSource>().loop = true;
			GetComponent<AudioSource> ().clip = pick;
			GetComponent<AudioSource> ().Play ();
			is_playing = true;
		}

		delay -= Time.deltaTime;
		return delay;
	}

	public int Payout()
	{
		GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().clip = open;
		GetComponent<AudioSource> ().Play ();
		GetComponent<AudioSource> ().loop = false;
		int temp = value;
		value = 0;
		is_open = true;
		GetComponent<SpriteRenderer> ().sprite = opened;
		return temp;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		delay = normDelay;
		GetComponent<AudioSource> ().Stop ();
		is_playing = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().clip = hit;
			GetComponent<AudioSource> ().Play ();
			GetComponent<AudioSource> ().loop = false;
		}
	}

}
