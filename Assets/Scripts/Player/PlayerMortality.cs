using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMortality : MonoBehaviour, IFaderListener
{
	public float fadeOutTime = 1f;
	public float force = 2f;
	private float fadeOutTimer = 0f;
	
	private Fader fader;
	
	private Animator animator;
	private AudioSource audioSource;
	public AudioClip dieClip2;
	public AudioClip dieClip1;
	public Rigidbody2D[] bodyParts;
	
	private bool restartEnabled = false;
	private bool died = false;
	
	void Start()
	{
		fader = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Fader>();
		animator = GetComponentInChildren<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		if(fadeOutTimer > 0)
		{
			fadeOutTimer -= Time.deltaTime;
			if(fadeOutTimer <= 0)
			{
				// Fade out
				Debug.Log ("Fade Out");
				fader.EndScene(this);
			}
		}
		
		if(Input.GetKeyDown (KeyCode.Return) && restartEnabled)
		{
			// Restart
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == Tags.enemy && !died)
			Die();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == Tags.enemy && !died)
			Die();
	}
	
	private void Die()
	{
		// Do explode
		died = true;
		animator.enabled = false;
		if(audioSource != null)
		{
			audioSource.Stop ();
			if(Random.value > 0.5f)
				audioSource.clip = dieClip1;
			else
				audioSource.clip = dieClip2;
			audioSource.Play ();
		}
		foreach(Rigidbody2D part in bodyParts)
		{
			part.gameObject.GetComponent<Collider2D>().enabled = true;
			part.AddForce (new Vector2(Random.value - 0.5f, 1) * force);
			part.transform.parent = this.transform;
		}
		// Start timer
		fadeOutTimer = fadeOutTime;
		
		GetComponent<Collider2D>().enabled = false;
		GetComponent<PlayerInput>().enabled = false;
		GetComponentInChildren<PlayerShoot>().enabled = false;
		GetComponentInChildren<PlayerGrab>().enabled = false;
		//GameObject.Destroy(this.gameObject);
	}
	
	public void OnFadeEnd()
	{
		// TODO: Enable restart controls
		restartEnabled = true;
		
		// Enable text
		GameObject[] texts = GameObject.FindGameObjectsWithTag(Tags.text);
		foreach(GameObject text in texts)
		{
			text.GetComponent<Text>().enabled = true;
		}
	}
}
