using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{
	public float cooldownTime = 1f;
	private float cooldownTimer;

	public float speed = 10f;
	public float range = 50f;
	public float scaleFactor = 1f;
	private ModifierActions actions;
	
	//private List<ShootEffect> effects;
	
	public GameObject particle;
	
	// Use this for initialization
	void Start () {
		actions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
		//effects = new List<ShootEffect>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(cooldownTimer > 0f)
			cooldownTimer -= Time.deltaTime;
		else if(Input.GetMouseButtonDown (0) && actions.getActionEnabled(ModifierActions.playerShoot) && actions.getActionEnabled (ModifierActions.notGrabbing))
		{
			Shoot();
			cooldownTimer = cooldownTime;
		}
		
		
		/*
		foreach(ShootEffect effect in effects)
		{
			effect.Update();
		}
		
		for(int i = 0; i < effects.Count; ++i)
		{
			if(effects[i].IsFinished ())
			{
				if(effects[i].getShootable() != null)
					effects[i].getShootable().Shoot ();
				effects.RemoveAt (i);
			}
		} */
	}
	
	void Shoot()
	{
		// Raycast
		RaycastHit2D cast = Physics2D.Raycast (this.transform.position, this.transform.right, range, LayerMask.GetMask (Layers.Environment));
		Vector3 endPos = this.transform.position + (this.transform.right * range);
		Vector2 end = cast.collider == null ? new Vector2(endPos.x, endPos.y) : cast.point;
		Debug.DrawLine (this.transform.position, end);
		
		GameObject spawn = (GameObject)GameObject.Instantiate(particle);
		spawn.transform.position = this.transform.position;
		Particle laser = spawn.transform.FindChild("Laser").gameObject.GetComponent<Particle>();
		laser.transform.position = Vector3.Lerp (this.transform.position, end, 0.5f);
		laser.transform.rotation = this.transform.rotation;
		
		float distance = Vector2.Distance (new Vector2(this.transform.position.x, this.transform.position.y), end);
		laser.transform.localScale = new Vector3(distance * scaleFactor, laser.transform.localScale.y, laser.transform.localScale.z);
		/*
		float duration = Vector2.Distance (new Vector2(this.transform.position.x, this.transform.position.y), end) / speed;
		ShootEffect newEffect = new ShootEffect(this.transform.position, end, 40, duration, particle);
		effects.Add (newEffect); */
		if(cast.collider != null && cast.collider.gameObject.tag == Tags.shootable)
		{
			Shootable shootable = cast.collider.gameObject.GetComponent<Shootable>();
			shootable.Shoot ();
			//newEffect.setShootable(shootable);
		}
	}
}
