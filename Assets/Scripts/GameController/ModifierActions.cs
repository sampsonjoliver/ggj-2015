using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifierActions : MonoBehaviour {
    private Dictionary<string, bool> actionList;

    public const string playerLeft = "left";
    public const string playerRight = "right";
    public const string playerJump = "jump";
    public const string playerShoot = "shoot";
    public const string playerGrab = "grab";
    public const string cameraEnabled = "blackout";

	// Use this for initialization
	void Start () {
        actionList = new Dictionary<string, bool>();
	}

    public void setActionEnabled(string actionName, bool isEnabled)
    {
        actionList[actionName] = isEnabled;
    }

    public bool getActionEnabled(string actionName)
    {
        bool isEnabled;
        bool exists = actionList.TryGetValue(actionName, out isEnabled);
        if (!exists)
            return true;
        return isEnabled;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}