using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public float defaultFadeSpeed = 0.5f;
    public GameObject UiCanvasFader;

    private bool isSceneStarting = true;
    private bool isSceneEnding = false;

    private bool isFadeRequested = false;
    private float currentFadeSpeed;
    private Color requestedFadeColor;

    private Image faderImage;

	// Use this for initialization
	void Awake () {
        faderImage = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<Image>();
        faderImage.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSceneStarting)
            isSceneStarting = !FadeToClear(defaultFadeSpeed);
        else if (isSceneEnding)
        {
            isSceneEnding = !FadeToBlack(defaultFadeSpeed);

            if (!isSceneEnding)
            {
                // TODO notify things of us having finished the scene now.
                // Most like this'll be when the player is dead and we need to load
                // the level again. Or when finishing a level and loading a new one.
            }
        }
        else if (isFadeRequested)
        {
            FadeToColor(requestedFadeColor, currentFadeSpeed);
        }
	}

    void StartScene()
    {
        isSceneStarting = true;
    }

    void EndScene()
    {
        isSceneStarting = false;
    }

    bool FadeToClear(float fadeSpeed)
    {
        FadeToColor(Color.clear, fadeSpeed);

        if (faderImage.color.a <= 0.05f)
        {
            faderImage.color = Color.clear;
            faderImage.enabled = false;
            return true;
        }
        return false;
    }

    bool FadeToBlack(float fadeSpeed)
    {
        FadeToColor(Color.black, fadeSpeed);

        if (faderImage.color.a >= 0.95f)
        {
            faderImage.color = Color.black;
            return true;
        }
        return false;
    }

    private void FadeToColor(Color color, float fadeSpeed)
    {
        faderImage.color = Color.Lerp(faderImage.color, color, fadeSpeed * Time.deltaTime);
    }

}
