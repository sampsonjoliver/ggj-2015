using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGrab : MonoBehaviour
{
	private Grabbable closestGrab;
	private Grabbable grabbed;
	private ModifierActions playerActions;
	
	// Use this for initialization
	void Start ()
	{
		playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1) && playerActions.getActionEnabled(playerActions.playerGrab))
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
				grab.IsSelected(true);
			}
			if(Vector3.Distance (this.transform.position, grab.transform.position) < Vector3.Distance (this.transform.position, closestGrab.transform.position))
			{
				closestGrab.IsSelected(false);
				closestGrab = grab;
				grab.IsSelected(true);
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
				closestGrab.IsSelected(false);
				closestGrab = null;
			}
		}
	}
	
	private void Drop()
	{
		grabbed.transform.parent = null;
		grabbed.collider2D.enabled = true;
		grabbed.rigidbody2D.isKinematic = false;
		grabbed = null;
	}
	
	private void Grab()
	{
		grabbed = closestGrab;
		grabbed.transform.parent = this.transform;
		grabbed.transform.localPosition = Vector3.zero;
		grabbed.collider2D.enabled = false;
		grabbed.rigidbody2D.isKinematic = true;
	}
}
