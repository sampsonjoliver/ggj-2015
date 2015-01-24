using UnityEngine;
using System.Collections;

public class ModifierBehaviour : MonoBehaviour {
    public string actionModified;
    private ModifierActions modifierActions;
    private Collider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
        modifierActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
	}
	
    void OnTriggerEnter2D(Collider2D other) {
        if (other == modifiedObject)
        {
            modifierActions.setActionEnabled(actionModified, false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == modifiedObject)
        {
            modifierActions.setActionEnabled(actionModified, true);
        }
    }
}
