using UnityEngine;
using System.Collections;

public class Button : Switch {
    public bool lockedOn = false;
    private Collider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    protected override void SwitchStateOn()
    {
        // TODO flip any lights and such

        Debug.Log("Toggled on");
        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(true);
        }
    }

    protected override void SwitchStateOff()
    {
        // TODO Flip any lights and such

        Debug.Log("Toggled off");
        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(false);
        }
    }
}
