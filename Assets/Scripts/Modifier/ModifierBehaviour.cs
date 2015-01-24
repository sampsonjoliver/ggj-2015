using UnityEngine;
using System.Collections;

public class ModifierBehaviour : MonoBehaviour {
    public string actionModified;
    public GameObject target;
    private ModifierActions modifierActions;
    private Collider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
        modifierActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Disable: " + actionModified);
        if (other.gameObject == target)
        {
            Debug.Log("Disable: " + actionModified);
            modifierActions.setActionEnabled(actionModified, false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Enable: " + actionModified);
            modifierActions.setActionEnabled(actionModified, true);
        }
    }
}
