using UnityEngine;
using System.Collections;

public class DoorSwitchBehaviour : Switchable {
    private Animator anim;
    private AnimatorHashIds hash;

    void Start()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AnimatorHashIds>();
    }

    protected override void SwitchStateOn()
    {
        // TODO animate me
        anim.SetBool(hash.buttonStateBool, true);
    }

    protected override void SwitchStateOff()
    {
        // TODO animate me
        anim.SetBool(hash.buttonStateBool, false);
    }
}
