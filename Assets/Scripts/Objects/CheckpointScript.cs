using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	public Sprite image1;
	public Sprite image2;

	public Transform spawnpoint;
	public AudioSource soundEFX;

	float playCount = 0;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playCount == 1) 
		{
			soundEFX.Play();
			playCount++;
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			spawnpoint.position = this.transform.position;
			GetComponent<SpriteRenderer>().sprite = image2;
			playCount++;
		}
	}

}
