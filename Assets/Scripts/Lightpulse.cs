using UnityEngine;
using System.Collections;

public class Lightpulse : MonoBehaviour {
	public float localIntense;
	public float intenseChange;
	public bool intenseEbb = true;
	public float intenseMax;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update ()
	{
		if (intenseEbb)
		{
			localIntense += intenseChange*Time.deltaTime;
		}
		else
		{
			localIntense -= intenseChange*Time.deltaTime;
		}
		if (localIntense > intenseMax) {
			intenseEbb = !intenseEbb;
		} else if (localIntense < 0) {
			intenseEbb = !intenseEbb;
		}
		this.light.intensity = localIntense;
	}
}
