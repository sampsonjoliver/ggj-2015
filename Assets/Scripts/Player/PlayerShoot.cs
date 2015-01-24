using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public float cooldownTime = 1f;
	private float cooldownTimer;
	private ModifierActions actions;
	
	// Use this for initialization
	void Start () {
		actions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(cooldownTimer > 0f)
			cooldownTimer -= Time.deltaTime;
		else if(Input.GetMouseButtonDown (0) && actions.getActionEnabled(actions.playerShoot))
		{
			Shoot();
			cooldownTimer = cooldownTime;
		}
	}
	
	void Shoot()
	{
		// Raycast
		RaycastHit2D cast = Physics2D.Raycast (this.transform.position, this.transform.right, 10, LayerMask.GetMask (Layers.Environment));
		Vector3 endPos = this.transform.position + (this.transform.right * 10);
		Vector2 end = cast.collider == null ? new Vector2(endPos.x, endPos.y) : cast.point;
		Debug.DrawLine (this.transform.position, end);
		
		if(cast.collider != null && cast.collider.gameObject.tag == Tags.shootable)
		{
			Shootable shootable = cast.collider.gameObject.GetComponent<Shootable>();
			shootable.Shoot();
		}
	}
}
