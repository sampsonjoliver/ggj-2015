using UnityEngine;
using System.Collections;

public class PlayerArm : MonoBehaviour
{
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse = Input.mousePosition;
		Vector3 arm = Camera.main.WorldToScreenPoint(this.transform.position);
		Vector3 dir = mouse - arm;
		//dir.Normalize();
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		//this.transform.rotation = Quaternion.L
		//this.transform.rotation = Quaternion.LookRotation(dir);
		this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
