using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public float defaultFadeSpeed = 0.5f;

    private bool isSceneStarting = true;
    private bool isSceneEnding = false;

    private bool isFadeRequested = false;
    private float currentFadeSpeed;
    private bool requestedFadeEnabledState;

    private Image faderImage;
    
    private IFaderListener listener;

	// Use this for initialization
	void Awake () {
        faderImage = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<Image>();
        faderImage.color = Color.black;
        currentFadeSpeed = defaultFadeSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSceneStarting)
		{
			faderImage.enabled = true;
            if (FadeToClear(defaultFadeSpeed))
            {
                isSceneStarting = false;
                //Debug.Log("Scene Started");
            }
        }
        else if (isSceneEnding)
        {
			faderImage.enabled = true;
            if (FadeToBlack(defaultFadeSpeed))
            {
                isSceneEnding = false;
                //Debug.Log("Scene Ended");
                if(listener != null)
                	listener.OnFadeEnd();
                // TODO notify things of us having finished the scene now.
                // Most like this'll be when the player is dead and we need to load
                // the level again. Or when finishing a level and loading a new one.
            }
        }
        else if (isFadeRequested)
        {
            faderImage.enabled = true;
            if (requestedFadeEnabledState)
            {
                Debug.Log("Black Fade Requested");
                if (FadeToBlack(currentFadeSpeed))
                {
                    Debug.Log("Black Fade Ended");
                    isFadeRequested = false;
                    currentFadeSpeed = defaultFadeSpeed;
                }
            }
            else
            {
                Debug.Log("Clear Fade Requested");
                if (FadeToClear(currentFadeSpeed))
                {
                    Debug.Log("Clear Fade Ended");
                    isFadeRequested = false;
                    currentFadeSpeed = defaultFadeSpeed;
                }
            }
        }
	}

    public void RequestFade(bool isFadeEnabled, float fadeSpeed, IFaderListener listener = null)
    {
        this.requestedFadeEnabledState = isFadeEnabled;
        currentFadeSpeed = fadeSpeed;
        this.isFadeRequested = true;
        this.listener = listener;
    }

    void StartScene(IFaderListener listener = null)
    {
        isSceneStarting = true;
		this.listener = listener;
    }

    public void EndScene(IFaderListener listener = null)
    {
        isSceneEnding = true;
		this.listener = listener;
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
