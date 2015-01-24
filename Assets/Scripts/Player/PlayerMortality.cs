using UnityEngine;
using System.Collections;

public class PlayerMortality : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == Tags.enemy)
			Die();
	}
	
	private void Die()
	{
		GameObject.Destroy(this.gameObject);
	}
}
