using UnityEngine;
using System.Collections;

public abstract class Switchable : MonoBehaviour {
    protected bool isSwitchedStateOn;

    public void ToggleSwitchState(bool isSwitchOn)
    {
        this.isSwitchedStateOn = isSwitchOn;
        if (isSwitchedStateOn)
            SwitchStateOn();
        else
            SwitchStateOff();
    }

    public bool GetSwitchState()
    {
        return this.isSwitchedStateOn;
    }

    protected abstract void SwitchStateOn();
    protected abstract void SwitchStateOff();
}
