using UnityEngine;
using System.Collections;

public class PlayerArm : MonoBehaviour
{
    //private PlayerInput input; // Not currently used.
    public Transform followTransform;
    private Vector3 mouse,oldmouse,dir;
	// Use this for initialization
	void Start ()
    {
        //input = GetComponentInParent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // DON'T FUCKING CHANGE THIS SHIT - nvm, fix this shit - nvm, all g :'D
		mouse = Input.mousePosition;
		//if(mouse!=oldmouse)
		//{
			Vector3 arm = Camera.main.WorldToScreenPoint(this.transform.position);
			//Vector3 dir = !input.IsPlayerFacingRight() ? mouse - arm : arm - mouse;
        	dir = mouse - arm;
        //}
        //else
        //{
        //	dir = new Vector3(Input.GetAxis("Horizontal1"),-Input.GetAxis ("Vertical1"));
        //}
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		Vector3 pos = followTransform.position;
		pos.z -= 0.5f;
        this.transform.position = pos;
        //oldmouse = mouse;
	}
}
