using UnityEngine;
using System.Collections;

public class BoxShootable : Shootable
{
	public override void Shoot()
	{
        Debug.Log("things");
		GameObject.Destroy (this.gameObject);
	}
}
