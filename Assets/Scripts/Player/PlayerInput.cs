using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    private ModifierActions playerActions;
    private bool isFacingRight;

    private const float horizontalVelocity = 10f;
    private const float gravityVelocity = 9.81f;
    private const float jumpVelocity = 10f;

	// Use this for initialization
	void Start () {
        playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();    
	}
	
	// Update is called once per frame
	void Update () {
        //ApplyGravity();
        HandleHorizontalMovement();
        

        // Jump + other stuff
	}

    void HandleHorizontalMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement < 0f && playerActions.getActionEnabled(playerActions.playerLeft))
        {
            // Apply velocity left
            rigidbody2D.velocity = new Vector2(-horizontalVelocity, rigidbody2D.velocity.y);
            isFacingRight = false;
        }
        else if (horizontalMovement > 0f && playerActions.getActionEnabled(playerActions.playerRight))
        {
            // Other things
            rigidbody2D.velocity = new Vector2(horizontalVelocity, rigidbody2D.velocity.y);
            isFacingRight = true;
        }
    }

    void HandleVerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    void ApplyGravity()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y - (gravityVelocity * Time.deltaTime));
    }

    void SetPlayerFacingDirection(bool isFacingRight)
    {
        if (this.isFacingRight != isFacingRight)
        {
            this.isFacingRight = isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
