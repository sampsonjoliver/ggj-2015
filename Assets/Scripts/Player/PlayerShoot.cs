using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{
	public float cooldownTime = 1f;
	private float cooldownTimer;
	public float speed = 10f;
	private ModifierActions actions;
	
	private List<ShootEffect> effects;
	
	public GameObject particle;
	
	// Use this for initialization
	void Start () {
		actions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
		effects = new List<ShootEffect>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(cooldownTimer > 0f)
			cooldownTimer -= Time.deltaTime;
		else if(Input.GetMouseButtonDown (0) && actions.getActionEnabled(ModifierActions.playerShoot))
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
		RaycastHit2D cast = Physics2D.Raycast (this.transform.position, this.transform.right, 10, LayerMask.GetMask (Layers.Environment));
		Vector3 endPos = this.transform.position + (this.transform.right * 10);
		Vector2 end = cast.collider == null ? new Vector2(endPos.x, endPos.y) : cast.point;
		Debug.DrawLine (this.transform.position, end);
		
		GameObject spawn = (GameObject)GameObject.Instantiate(particle);
		spawn.transform.parent = this.transform;
		spawn.transform.localPosition = Vector3.zero;
		/*
		float duration = Vector2.Distance (new Vector2(this.transform.position.x, this.transform.position.y), end) / speed;
		ShootEffect newEffect = new ShootEffect(this.transform.position, end, 40, duration, particle);
		effects.Add (newEffect); */
		if(cast.collider != null && cast.collider.gameObject.tag == Tags.shootable)
		{
            Debug.Log(";lkdsahnfkilah");
			Shootable shootable = cast.collider.gameObject.GetComponent<Shootable>();
			shootable.Shoot ();
			//newEffect.setShootable(shootable);
		}
	}
}
