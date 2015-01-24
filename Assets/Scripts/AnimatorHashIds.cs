using UnityEngine;
using System.Collections;

public class AnimatorHashIds : MonoBehaviour
{
    public int walkingBool;
    public int jumpingBool;
    public int fallingBool;

    public int idleState;
    public int walkState;
    public int jumpState;
    public int fallState;
    public int landState;

    void Awake()
    {
        walkingBool = Animator.StringToHash("IsWalking");
        jumpingBool = Animator.StringToHash("IsJumping");
        fallingBool = Animator.StringToHash("IsFalling");

        idleState = Animator.StringToHash("Base Layer.idle");
        walkState = Animator.StringToHash("Base Layer.Jump");
        jumpState = Animator.StringToHash("Base Layer.ROBOTWalk");
        fallState = Animator.StringToHash("Base Layer.ROBOfall");
        landState = Animator.StringToHash("Base Layer.ROBOland");

    }
}
