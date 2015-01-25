using UnityEngine;
using System.Collections;

public class Button : Switch {
    public Color onColor = Color.green;
    public Color offColor = Color.red;
    private Collider2D collider;
    private Light light;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
        light = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    protected override void SwitchStateOn()
    {
        // TODO flip any lights and such
        SetColor(isSwitchedStateOn);

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
        SetColor(isSwitchedStateOn);

        Debug.Log("Toggled off");
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
