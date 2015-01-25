using UnityEngine;
using System.Collections;

public class PlayerArm : MonoBehaviour
{
    private PlayerInput input;
    public Transform followTransform;
	// Use this for initialization
	void Start () {
        input = GetComponentInParent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update () {
        // DON'T FUCKING CHANGE THIS SHIT - nvm, fix this shit - nvm, all g :'D
		Vector3 mouse = Input.mousePosition;
		Vector3 arm = Camera.main.WorldToScreenPoint(this.transform.position);
		//Vector3 dir = !input.IsPlayerFacingRight() ? mouse - arm : arm - mouse;
        Vector3 dir = mouse - arm;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		Vector3 pos = followTransform.position;
		pos.z -= 0.5f;
        this.transform.position = pos;
	}
}
