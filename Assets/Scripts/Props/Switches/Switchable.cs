using UnityEngine;
using System.Collections;

public abstract class Switchable : MonoBehaviour {
    protected bool isSwitchedStateOn;

	public AudioClip audioOn;
	public AudioClip audioOff;
	private AudioSource audioSource;
	
	public void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
    public void ToggleSwitchState(bool isSwitchOn)
    {
        this.isSwitchedStateOn = isSwitchOn;
        if (isSwitchedStateOn)
        {
            SwitchStateOn();
            if(audioSource != null && !audioSource.isPlaying)
            {
            	audioSource.clip = audioOn;
            	audioSource.Play ();
            }
        }
        else
        {
            SwitchStateOff();
			if(audioSource != null && !audioSource.isPlaying)
			{
				audioSource.clip = audioOff;
				audioSource.Play ();
			}
        }
    }

    public bool GetSwitchState()
    {
        return this.isSwitchedStateOn;
    }

    protected abstract void SwitchStateOn();
    protected abstract void SwitchStateOff();
}
