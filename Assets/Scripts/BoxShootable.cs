using UnityEngine;
using System.Collections;

public class BoxShootable : Shootable
{
	public override void Shoot()
	{
		Destroy (this.gameObject);
	}
}
