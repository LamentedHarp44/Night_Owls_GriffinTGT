using UnityEngine;
using System.Collections;

public enum LIGHT_LEVEL {invisible = 0, dark =1, shadow = 2, normal = 3, full = 4, bright = 5}

public class Invisiblilityscript : MonoBehaviour {

	PlayerController controller;
	bool invisActive = false;
	bool onCooldown = false;
	public float duration = 3;
	public float fullDuration = 3;
	int DurationIncreasePurchaseTracker = 0;
	public float cooldown = 0;
	public float fullCooldown = 30;
	int CooldownReductionPurchaseTracker = 0;
	int TrueInvisiblePurachaseTracker = 0;
	bool trueInvisiblePurchased = false;
	Animator anim;
	public int invisLevel;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (trueInvisiblePurchased == true) {
			invisLevel = 20;
		} else
			invisLevel = 1;

		//Shop menu upgrades. Setting variables appropriatly per upgrade purchased.
		//-------------------------------------------------------------------------
		CooldownReductionPurchaseTracker = PlayerPrefs.GetInt ("CooldownReduction");
		if (CooldownReductionPurchaseTracker == 1) 
		{
			fullCooldown -= 6;
			cooldown -= 6;
			PlayerPrefs.SetInt("CooldownReduction", 0);
		}

		DurationIncreasePurchaseTracker = PlayerPrefs.GetInt ("DurationIncrease");
		if (DurationIncreasePurchaseTracker == 1) 
		{
			fullDuration += 1;
			duration += 1;
			PlayerPrefs.SetInt("DurationIncrease", 0);
		}

		TrueInvisiblePurachaseTracker = PlayerPrefs.GetInt ("TrueInvisible");
		if (TrueInvisiblePurachaseTracker == 1) 
		{
			trueInvisiblePurchased = true;
			PlayerPrefs.SetInt("TrueInvisible", 0);
		}
		//-------------------------------------------------------------------------


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
				controller.lightExpo += invisLevel;

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
			controller.lightExpo -= invisLevel;

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
