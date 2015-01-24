using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    private ModifierActions playerActions;
    private Collider2D playerCollider;
    private bool isFacingRight;

    public float horizontalVelocity = 10f;
    public float jumpVelocity = 4f;

    private const float groundedMinDist = 0.3f;

	// Use this for initialization
	void Start () {
        playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
        playerCollider = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //ApplyGravity();
        HandleHorizontalMovement();
        HandleVerticalMovement();

        // Jump + other stuff
	}

    void HandleHorizontalMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        
        if (horizontalMovement < 0f && playerActions.getActionEnabled(ModifierActions.playerLeft))
        {
            // Apply velocity left
            rigidbody2D.velocity = new Vector2(-horizontalVelocity, rigidbody2D.velocity.y);
            SetPlayerFacingDirection(false);
        }
        else if (horizontalMovement > 0f && playerActions.getActionEnabled(ModifierActions.playerRight))
        {
            // Other things
            rigidbody2D.velocity = new Vector2(horizontalVelocity, rigidbody2D.velocity.y);
            SetPlayerFacingDirection(true);
        }
		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}
		
        // Jump + other stuff
	}

    void HandleVerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerActions.getActionEnabled(ModifierActions.playerJump))
        {
            if (CheckGrounded())
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpVelocity);
            }
        }
    }

    bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (playerCollider.collider2D.bounds.size.y / 2) + groundedMinDist, LayerMask.GetMask(Layers.Environment));
        if (hit.collider != null)
        {
            // We have hit the ground, huzzah
            Debug.Log("In contact with something at " + hit.distance);
            return true;
        }
        Debug.Log("Not contact with ground");
        return false;
    }

    void SetPlayerFacingDirection(bool isFacingRight)
    {
        if (this.isFacingRight != isFacingRight)
        {
            this.isFacingRight = isFacingRight;
            Vector3 theScale = transform.localScale;
            //theScale.x = isFacingRight ? 1 : -1;
            transform.localScale = theScale;
        }
    }
}
