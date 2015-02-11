using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private ModifierActions playerActions;
    private Collider2D playerCollider;
    private Animator anim;
    private AnimatorHashIds hash;
    private bool isFacingRight;
    private float horizontalMovement;

    public float horizontalVelocity = 10f;
    public float jumpVelocity = 4f;

    private const float groundedMinDist = 0.3f;
    
    //private AudioSource audioSource; // TODO: Add player sounds, like jumping, function fail use etc...

    public Transform transformToScale;

	// Use this for initialization
	void Start ()
    {
        // Getting the modifier array.
        playerActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
        // Getting the player's collider.
        playerCollider = gameObject.GetComponent<Collider2D>();
        // Getting player's audio component.
        //audioSource = GetComponent<AudioSource>();
        // Getting player's animation component.
        anim = GetComponentInChildren<Animator>();
        // Getting the animator hash array.
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AnimatorHashIds>();
	}
	
    void Update()
    {
        // Checking player input every frame.
        // Moving left right.
        horizontalMovement = Input.GetAxis("Horizontal");
        // Restarting level.
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        // Escaping to main.
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Application.LoadLevel("Main");
        }
        // Player jumping.
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && playerActions.getActionEnabled(ModifierActions.playerJump))
        {
            if (CheckGrounded())
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpVelocity);
                anim.SetBool(hash.jumpingBool, true);
            }
        }
    }

    // Handling physics based movement.
	void FixedUpdate ()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
	}

    // Moving the player up and down.
    void HandleHorizontalMovement()
    {
        if (horizontalMovement < 0f && playerActions.getActionEnabled(ModifierActions.playerLeft))
        {
            // Apply velocity left
            rigidbody2D.velocity = new Vector2(-horizontalVelocity, rigidbody2D.velocity.y);
            SetPlayerFacingDirection(false);
            anim.SetBool(hash.walkingBool, true);
        }
        else if (horizontalMovement > 0f && playerActions.getActionEnabled(ModifierActions.playerRight))
        {
            // Other things
            rigidbody2D.velocity = new Vector2(horizontalVelocity, rigidbody2D.velocity.y);
            SetPlayerFacingDirection(true);
            anim.SetBool(hash.walkingBool, true);
        }
		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            anim.SetBool(hash.walkingBool, false);
		}
	}

    // Moving the player up and down.
    void HandleVerticalMovement()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            anim.SetBool(hash.jumpingBool, false);
            anim.SetBool(hash.fallingBool, true);
        }
        else if (anim.GetBool(hash.fallingBool) == true && Mathf.Abs(rigidbody2D.velocity.y) <= 0.05f)
        {
            anim.SetBool(hash.fallingBool, false);
        }
    }

    // To check if player has landed on an environment object.
    bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (playerCollider.collider2D.bounds.size.y / 2) + groundedMinDist, LayerMask.GetMask(Layers.Environment));
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    // Turning character around if needed.
    public void SetPlayerFacingDirection(bool isFacingRight)
    {
        if (this.isFacingRight != isFacingRight)
        {
            this.isFacingRight = isFacingRight;
            Vector3 theScale = transformToScale.localScale;
            theScale.x = isFacingRight ? -Mathf.Abs(theScale.x) : Mathf.Abs(theScale.x);
            transformToScale.localScale = theScale;
        }
    }

    // Check facing direction.
    public bool IsPlayerFacingRight()
    {
        return this.isFacingRight;
    }

    // Flipping character...
    public void FlipPlayer()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
