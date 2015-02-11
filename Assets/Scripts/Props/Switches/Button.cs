using UnityEngine;
using System.Collections;

public class Button : Switch
{
    public Color onColor = Color.green;
    public Color offColor = Color.red;
    //private Collider2D collider; // Was not being used.
    private Light light;

	// Use this for initialization
	void Start ()
	{
		base.Start();
        //collider = GetComponent<Collider2D>();
        light = GetComponentInChildren<Light>();
	}

    protected override void SwitchStateOn()
    {
        // TODO flip any lights and such
        SetColor(isSwitchedStateOn);

        // Debug.Log("Toggled on");
        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(true);
        }
    }

    protected override void SwitchStateOff()
    {
        // TODO Flip any lights and such
        SetColor(isSwitchedStateOn);

        // Debug.Log("Toggled off");
        // Update attached objects
        foreach (Switchable affectedSwitch in affectedObjects)
        {
            affectedSwitch.ToggleSwitchState(false);
        }
    }

    void SetColor(bool isOn)
    {
        if (isOn)
            light.color = onColor;
        else
            light.color = offColor;
    }
}
