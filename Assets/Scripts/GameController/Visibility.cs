using UnityEngine;
using System.Collections;

public class Visibility : MonoBehaviour
{
    private ModifierActions actions;
    private Fader fader;
    private bool prevVisibility = true;

	// Use this for initialization
	void Start ()
    {
        actions = GetComponent<ModifierActions>();
        fader = GetComponent<Fader>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (prevVisibility && !actions.getActionEnabled(ModifierActions.cameraEnabled))
        {
            //Debug.Log("Black Fade Requested");
            fader.RequestFade(true, 10.0f);
            prevVisibility = false;
        }
        else if (!prevVisibility && actions.getActionEnabled(ModifierActions.cameraEnabled))
        {
            //Debug.Log("Clear Fade Requested");
            fader.RequestFade(false, 10.0f);
            prevVisibility = true;
        }
	}
}
