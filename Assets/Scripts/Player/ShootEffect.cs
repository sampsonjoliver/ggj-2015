using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEffect
{
	private GameObject particlePrefab;
	
	private bool finished;
	private int numParticles;
	private float duration;
	private float timer;
	private float particleDuration;
	private float particleSpawnTime;
	private Shootable shootable;
	
	private Vector3 start;
	private Vector3 end;
	
	public ShootEffect(Vector3 start, Vector3 end, int numParticles, float duration, GameObject particle)
	{
		this.start = start;
		this.end = end;
		this.numParticles = numParticles;
		this.duration = duration;
		this.timer = duration;
		this.particlePrefab = particle;
		this.particleSpawnTime = 0;
	}
	
	// Update is called once per frame
	public void Update ()
	{
		timer -= Time.deltaTime;
		if(timer > 0)
		{
			particleSpawnTime -= Time.deltaTime;
			if(particleSpawnTime <= 0)
			{
				SpawnParticle();
				particleSpawnTime = duration / numParticles;
			}
		}
	}
	
	public void setShootable(Shootable shootable)
	{
		this.shootable = shootable;
	}
	
	public Shootable getShootable()
	{
		return shootable;
	}
	
	public bool IsFinished()
	{
		return finished;
	}
	
	private void SpawnParticle()
	{
		GameObject spawn = (GameObject)GameObject.Instantiate(particlePrefab);
		float lerp = timer / duration;
		spawn.transform.position = Vector3.Lerp (end,start, lerp);
	}
}
