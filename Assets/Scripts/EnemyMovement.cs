using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public bool movingRight = true;
	public float moveSpeed = 20f;
	public float raycastPadding = 0.2f;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Do raycasts to check for obstacles in each direction
		float width = this.collider2D.bounds.size.x;
		float height = this.collider2D.bounds.size.y;
		Vector2 direction = movingRight ? Vector2.right : -Vector2.right;
		RaycastHit2D forwardCast = Physics2D.Raycast (this.transform.position, direction, width / 2 + raycastPadding, LayerMask.GetMask (Layers.Environment));
		RaycastHit2D downCast = Physics2D.Raycast ((Vector2)this.transform.position + direction, -Vector2.up, height / 2 + raycastPadding, LayerMask.GetMask (Layers.Environment));
		if(forwardCast.collider != null || downCast.collider == null)
			movingRight = !movingRight;
		this.rigidbody2D.velocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, this.rigidbody2D.velocity.y);
	}
}
