using UnityEngine;
using System.Collections;

public class PressurePadToggleable : Switch
{
    //private Collider2D collider; // Was not being used.
    private Animator anim;
    private AnimatorHashIds hash;
    private int colliderCount = 0;

	// Use this for initialization
	void Start ()
    {
		base.Start();
        //collider = GetComponent<EdgeCollider2D>();
        anim = transform.parent.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AnimatorHashIds>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {
            ++colliderCount;
            //Debug.Log("Object entered: " + other + ", count = " + colliderCount);
            // Switch toggled on
            if (colliderCount == 1)
            {
                //Debug.Log("Toggled on");
                ToggleSwitchState(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {
            --colliderCount;

            //Debug.Log("Object exited: " + other + ", count = " + colliderCount);

            // Switch toggled off
            if (colliderCount == 0)
            {
                //Debug.Log("Toggled off");
                ToggleSwitchState(false);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void SwitchStateOn()
    {
        // TODO set animation property
        anim.SetBool(hash.buttonStateBool, true);

        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(true);
        }
    }

    protected override void SwitchStateOff()
    {
        // TODO set animation property
        anim.SetBool(hash.buttonStateBool, false);
        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(false);
        }
    }
}
