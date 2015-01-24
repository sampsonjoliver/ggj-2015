using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour
{
	private Light light;
	
	// Use this for initialization
	void Start()
	{
		light = GetComponentInChildren<Light>();
	}
	
	public void SetLight(bool enabled)
	{
		if(light != null)
		{
			light.enabled = enabled;
		}
	}
}
