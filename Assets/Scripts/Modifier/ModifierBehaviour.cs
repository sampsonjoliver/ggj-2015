using UnityEngine;
using System.Collections;

public class ModifierBehaviour : MonoBehaviour {
    public string actionModified;
    public GameObject target;
    private ModifierActions modifierActions;
    private Collider2D collider;
    private SpriteRenderer modifierRegionOverlay;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider2D>();
        modifierActions = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<ModifierActions>();
        modifierRegionOverlay = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

        switch (actionModified)
        {
            case ModifierActions.playerLeft:
                modifierRegionOverlay.color = new Color(0.25f, 0.75f, 0.75f, 0.5f);
                break;
            case ModifierActions.playerRight:
                modifierRegionOverlay.color = new Color(0.75f,0.25f,0.25f,0.5f);
                break;
            case ModifierActions.playerJump:
                modifierRegionOverlay.color = new Color(0.75f,0.75f,0.75f,0.5f);
                break;
            case ModifierActions.playerShoot:
                modifierRegionOverlay.color = new Color(0.25f,0.75f,0.25f,0.5f);
                break;
            case ModifierActions.playerGrab:
                modifierRegionOverlay.color = new Color(0.25f,0.25f,0.75f,0.5f);
                break;
            case ModifierActions.cameraEnabled:
                modifierRegionOverlay.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
                break;
            default:
                modifierRegionOverlay.color = Color.clear;
                break;
        }
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
