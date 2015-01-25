using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    private DoorSwitchBehaviour doorBehaviour;
    public bool canExit = true;
	public string nextLevel;
	private bool exitLevel = false;
	private bool notQuite = false;
	private Fader myFader;
	public float fadeAmount;
	private float fadeCount;
	public float fadeSpeed;
	
	private AudioSource audioSource;
	public AudioClip winClip;
	
	void Start ()
	{
		fadeCount = 0.0f;
		myFader = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponentInChildren<Fader>();
        doorBehaviour = GetComponent<DoorSwitchBehaviour>();
        audioSource = GetComponent<AudioSource>();
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && canExit)
		{
			// Audio
			if(audioSource != null && !audioSource.isPlaying)
			{
				audioSource.clip = winClip;
				audioSource.Play();
			}
			exitLevel = true;
			other.GetComponent<PlayerInput>().enabled = false;
			other.rigidbody2D.velocity = new Vector2(0.0f,0.0f);	
		}
	}
	
	public void Update()
	{
        canExit = doorBehaviour.GetSwitchState();
		if(exitLevel && canExit)
		{
			exitLevel = false;
			notQuite = true;
			fadeCount = 0;
		}
		if(notQuite)
		{
			myFader.RequestFade (true,fadeSpeed);
			fadeCount += Time.deltaTime;			
		}
		if(fadeCount >= fadeSpeed)
		{
			Application.LoadLevel(nextLevel);
		}
	}
}
