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

    public AudioSource audioSource;
    public AudioClip grabClip;
    public AudioClip releaseClip;
    public AudioClip actionFailClip;
	
	// Use this for initialization
	void Start ()
	{
		playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (playerActions.getActionEnabled(ModifierActions.playerGrab))
            {
                if (grabbed != null)
                {
                    Drop();
                }
                else if (closestGrab != null)
                {
                    Grab();
                }
            }
            else
            {
                PlayClip(actionFailClip, true);
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
				closestGrab.SetLight (true);
			}
			if(Vector3.Distance (this.transform.position, grab.transform.position) < Vector3.Distance (this.transform.position, closestGrab.transform.position))
			{
				closestGrab.SetLight (false);
				closestGrab = grab;
				closestGrab.SetLight (true);
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
				closestGrab.SetLight (false);
				closestGrab = null;
			}
		}
	}
	
	private void Drop()
	{
		grabbed.transform.parent = null;
		grabbed.collider2D.isTrigger = false;
		grabbed.rigidbody2D.isKinematic = false;
		grabbed.SetLight (true);
		closestGrab = grabbed;
		grabbed = null;
		light.enabled = false;
		playerActions.setActionEnabled(ModifierActions.notGrabbing, true);
        PlayClip(releaseClip, true);
	}

    private void Grab()
    {
        grabbed = closestGrab;
        grabbed.transform.parent = this.transform;
        grabbed.transform.localPosition = new Vector3(0, 0, grabbed.transform.position.z);
        grabbed.collider2D.isTrigger = true;
        grabbed.rigidbody2D.isKinematic = true;
        grabbed.SetLight(true);
        light.enabled = true;
        playerActions.setActionEnabled(ModifierActions.notGrabbing, false);
        PlayClip(grabClip, true);
    }

    private void PlayClip(AudioClip clip, bool overridePlaying = false)
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying && overridePlaying)
            {
                audioSource.Stop();
            }

            if (!audioSource.isPlaying && clip != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
