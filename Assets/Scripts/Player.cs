using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	public bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public bool SPAAACE = false;
	
	void Start()
	{
	}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y-1.0f),groundRadius,whatIsGround);
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !facingRight)
		{
			Flip ();
		}
		else if (move < 0 && facingRight)
		{
			Flip();
		}
	}
	
	void Update()
	{
		SPAAACE = false;
		if(Input.GetKeyDown (KeyCode.Space))
		{
			SPAAACE = true;
		}
		if(grounded&&SPAAACE)
		{
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}