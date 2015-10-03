using UnityEngine;
using System.Collections;

public enum LIGHT_LEVEL {invisible = 0, dark =1, shadow = 2, normal = 3, full = 4, bright = 5}

public class Invisiblilityscript : MonoBehaviour {

	PlayerController controller;
	bool invisActive = false;
	bool onCooldown = false;
	public float duration = 3;
	public float fullDuration = 3;
	public float cooldown = 0;
	public float fullCooldown = 30;
	Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (controller == null)
			controller = gameObject.GetComponent<PlayerController> ();


		if (invisActive) 
		{
			duration -= Time.deltaTime;
			anim.SetBool("Invisible", true);
			if(duration <= 0)
			{
				anim.SetBool("Invisible", false);
				invisActive = false;
				duration = fullDuration;
				onCooldown = true;
				controller.lightExpo += 1;
			}
		}
		if (onCooldown) 
		{
			cooldown -= Time.deltaTime;
			if(cooldown <= 0)
			{
				cooldown = fullCooldown;
				onCooldown = false;
			}
		}
	}

	public void SetExposure(int i)
	{
		controller.lightExpo = i;
	}

	public bool IsActive()
	{
		return invisActive;
	}

	public void Invisibility()
	{
		if (!onCooldown && !invisActive) 
		{
			invisActive = true;
			controller.lightExpo -= 1;
			if (controller.lightExpo < 0)
				controller.lightExpo = 0;
		}

	}

	public int LightExposure()
	{
		if (controller != null)
			return controller.lightExpo;
		else
			return 0;
	}

	public bool IsOnCoolDown(){
		return onCooldown;
	}
}
