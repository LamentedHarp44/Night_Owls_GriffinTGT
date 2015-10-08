using UnityEngine;
using System.Collections;

public class delayboxscript : MonoBehaviour {

	public GameObject smashedCrate;
	public GameObject newCrate;
	public AudioClip clip;


	// Use this for initialization
	void Start () 
	{
		newCrate = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Floor") 
		{
			newCrate = Instantiate(smashedCrate);
			newCrate.transform.position = transform.position;
			newCrate.GetComponent<AudioSource>().Play();
			Destroy(this.gameObject);

		}

	}





}
