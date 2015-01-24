using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEffect
{
	private List<GameObject> particles;
	public GameObject particlePrefab;
	
	private bool finished;
	public int numParticles;
	
	private float duration;
	private float timer;
	
	private Vector3 start;
	private Vector3 end;
	
	public ShootEffect(Vector3 start, Vector3 end, int numParticles, float duration, GameObject particle)
	{
		this.start = start;
		this.end = end;
		this.numParticles = numParticles;
		this.duration = duration;
		this.timer = duration;
		particlePrefab = particle;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool IsFinished()
	{
		return finished;
	}
}
