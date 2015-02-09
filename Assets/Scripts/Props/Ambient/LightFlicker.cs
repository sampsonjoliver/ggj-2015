using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
    public Light activeLight;
    public float flickerTime;
    public bool smoothFlicker;
    public float maxIntensity, minIntensity;
    public bool randomise;
    public float randomVariance = 0.5f;

    private bool isLightOn;
    private bool isLightTurningOff;
    private float timer;
    private float realFlickerTime;

    void Start()
    {
        if (activeLight.enabled && activeLight.intensity > minIntensity)
        {
            isLightOn = true;
        }
        isLightTurningOff = isLightOn;
        realFlickerTime = flickerTime;
        timer = 0f;
    }
	
	// Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // If smooth, then LERP across interval
        // If not smooth, then on-off after interval
        // If random smooth, then periodically flip direction
        // If random, periodically flip direction
        if (timer >= realFlickerTime)
        {
            if (randomise)
            {
                float randTime = Random.value;
                realFlickerTime = flickerTime + (((randTime - 1) * 2) * randomVariance);
                Debug.Log("Real flicker rand: " + realFlickerTime);
                isLightTurningOff = Random.value >= 0.5f;
            }
            else
            {
                realFlickerTime = flickerTime;
            }
        }

        if (smoothFlicker)
        {
            float tPerc = timer / realFlickerTime;
            if (isLightTurningOff)
            {
                activeLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, tPerc);
                if (timer >= realFlickerTime)
                {
                    if (!randomise)
                        isLightTurningOff = !isLightTurningOff;
                    timer = 0f;
                }
            }
            else
            {
                activeLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, tPerc);
                if (timer >= realFlickerTime)
                {
                    if (!randomise)
                        isLightTurningOff = !isLightTurningOff;
                    timer = 0f;
                }
            }
        }
        else if (timer >= realFlickerTime)
        {
            activeLight.intensity = isLightTurningOff ? minIntensity : maxIntensity;
            isLightTurningOff = !isLightTurningOff;
            timer = 0f;
        }
        /*
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
        }*/
	}
}
