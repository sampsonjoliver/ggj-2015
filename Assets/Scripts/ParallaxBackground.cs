using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour
{
	public Transform trackedTransform;
	private Vector2 previousPosition;
	public float moveFraction = 0.05f;
	
	public bool moveVertical = true;
	public bool moveHorizontal = true;
	
	void Start()
	{
		previousPosition = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	// Update is called once per frame
	void Update ()
	{
		Vector2 pos = new Vector2(trackedTransform.position.x, trackedTransform.position.y);
		Vector2 delta = (previousPosition - pos) * moveFraction;
		if(!moveVertical)
			delta.y = 0;
		if(!moveHorizontal)
			delta.x = 0;
		previousPosition = pos;
		this.transform.position = new Vector3(this.transform.position.x + delta.x, this.transform.position.y + delta.y, this.transform.position.z);
	}
}
