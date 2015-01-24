using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGrab : MonoBehaviour
{
	private Grabbable closestGrab;
	private Grabbable grabbed;
	private ModifierActions playerActions;
	public Color highlightColor;
	public Color grabColor;
	private Light light;
	
	// Use this for initialization
	void Start ()
	{
		playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && playerActions.getActionEnabled(ModifierActions.playerGrab))
		{
			if(grabbed != null)
			{
				Drop();
			}
			else if(closestGrab != null)
			{
				Grab();
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == Tags.grabbable && grabbed == null)
		{
			Grabbable grab = other.GetComponent<Grabbable>();
			if(closestGrab == null)
			{
				closestGrab = grab;
				grab.SetColor (highlightColor);
			}
			if(Vector3.Distance (this.transform.position, grab.transform.position) < Vector3.Distance (this.transform.position, closestGrab.transform.position))
			{
				closestGrab.SetColor (Color.white);
				closestGrab = grab;
				grab.SetColor (highlightColor);
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == Tags.grabbable)
		{
			Grabbable grab = other.GetComponent<Grabbable>();
			if(grab == closestGrab)
			{
				grab.SetColor (Color.white);
				closestGrab = null;
			}
		}
	}
	
	private void Drop()
	{
		grabbed.transform.parent = null;
		//grabbed.collider2D.enabled = true;
        grabbed.collider2D.isTrigger = false;
		grabbed.rigidbody2D.isKinematic = false;
		grabbed.SetColor (Color.white);
		grabbed = null;
		light.enabled = false;
		playerActions.setActionEnabled(ModifierActions.notGrabbing, true);
	}
	
	private void Grab()
	{
		grabbed = closestGrab;
		grabbed.transform.parent = this.transform;
		grabbed.transform.localPosition = Vector3.zero;
		//grabbed.collider2D.enabled = false;
        grabbed.collider2D.isTrigger = true;
		grabbed.rigidbody2D.isKinematic = true;
		grabbed.SetColor (grabColor);
		light.enabled = true;
		playerActions.setActionEnabled(ModifierActions.notGrabbing, false);
	}
}
