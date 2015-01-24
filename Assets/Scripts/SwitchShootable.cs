using UnityEngine;
using System.Collections;

public class SwitchShootable : Shootable {
    private Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}

    public override void Shoot()
    {
        button.ToggleSwitchState(!button.GetSwitchState());
    }
}
