using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
    public Light activeLight;
    public float flickerTime;
    public bool smoothFlicker;
    public float maxIntensity, minIntensity;
    public bool randomise;
    public float randomDamping = 0.05f;

    private bool isLightOn;
    private bool isLightTurningOff;
    private float timer;

    void Start()
    {
        if (activeLight.enabled && activeLight.intensity > minIntensity)
        {
            isLightOn = true;
        }
        isLightTurningOff = isLightOn;
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        float mod = 0f;
        timer += Time.deltaTime;

        if (smoothFlicker)
        {
            float t = timer / flickerTime;
            if (isLightTurningOff && activeLight.intensity > minIntensity)
            {
                activeLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t) + mod;
                if (activeLight.intensity <= minIntensity + 0.05f)
                {
                    isLightOn = false;
                    if (smoothFlicker)
                    {
                        Debug.Log("mod " + mod);
                        Debug.Log("intensity " + activeLight.intensity);
                        Debug.Log("timer reset " + timer);
                        timer = 0f;
                    }
                }
            }
            else if (!isLightTurningOff && activeLight.intensity < maxIntensity)
            {
                activeLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t) + mod;
                if (activeLight.intensity >= maxIntensity - 0.05f)
                {
                    isLightOn = true;
                    if (smoothFlicker)
                    {
                        Debug.Log("mod " + mod);
                        Debug.Log("intensity " + activeLight.intensity);
                        Debug.Log("timer reset " + timer);
                        timer = 0f;
                    }
                }
            }
        }
        else
        {
            if (timer >= flickerTime)
            {
                activeLight.intensity = isLightTurningOff ? minIntensity : maxIntensity;
                isLightOn = !isLightTurningOff;
                timer = 0f;
            }
        }

        if (randomise)
        {
            if (smoothFlicker)
            {
                mod = (Random.value * randomDamping);
                mod -= (randomDamping * 0.5f);
            }
            if (timer >= flickerTime - mod)
            {
                isLightTurningOff = Random.value >= 0.5f;
                timer = 0f;
            }
        }
        else
        {
            isLightTurningOff = isLightOn;
        }
	}
}
