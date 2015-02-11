using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    // Sprite used to black screen.
    public Sprite defaultFader;
    // Default time it takes to fade.
    public float defaultFadeSpeed = 4f;
    // Variables to have a fade in and out of the scene.
    private bool isSceneStarting = true;
    private bool isSceneEnding = false;
    // Variable to set own fade.
    private bool isFadeRequested = false;
    // Current fade time.
    private float currentFadeSpeed;
    private bool requestedFadeEnabledState;
    private Image faderImage;
    private IFaderListener listener;

	// Use this for initialization
	void Awake ()
    {
        faderImage = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<Image>();
        faderImage.color = Color.black;
        currentFadeSpeed = defaultFadeSpeed;
        if (defaultFader != null)
        {
            faderImage.sprite = defaultFader;
        }
        else
        {
            defaultFader = faderImage.sprite;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Level start fade in.
        if (isSceneStarting)
		{
            faderImage.enabled = true;
            faderImage.sprite = defaultFader;
            if (FadeToClear(defaultFadeSpeed))
            {
                isSceneStarting = false;
            }
        }
        // Level end fade out.
        else if (isSceneEnding)
        {
            faderImage.enabled = true;
            faderImage.sprite = defaultFader;
            if (FadeToBlack(defaultFadeSpeed))
            {
                isSceneEnding = false;
                if(listener != null)
                	listener.OnFadeEnd();
                // TODO notify things of us having finished the scene now.
                // Most like this'll be when the player is dead and we need to load
                // the level again. Or when finishing a level and loading a new one.
            }
        }
        // Custom fade requested.
        else if (isFadeRequested)
        {
            faderImage.enabled = true;
            if (requestedFadeEnabledState)
            {
                if (FadeToBlack(currentFadeSpeed))
                {
                    isFadeRequested = false;
                    currentFadeSpeed = defaultFadeSpeed;
                }
            }
            else
            {
                if (FadeToClear(currentFadeSpeed))
                {
                    isFadeRequested = false;
                    currentFadeSpeed = defaultFadeSpeed;
                }
            }
        }
	}

    // 
    public void RequestFade(bool isFadeEnabled, float fadeSpeed, IFaderListener listener = null, Sprite imageSprite = null)
    {
        if (imageSprite != null)
        {
            this.faderImage.sprite = imageSprite;
        }
        else
        {
            this.faderImage.sprite = defaultFader;
        }
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

    // Fading in.
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

    // Fading out.
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

    // Fading the alpha channel for specified time.
    private void FadeToColor(Color color, float fadeSpeed)
    {
        faderImage.color = Color.Lerp(faderImage.color, color, fadeSpeed * Time.deltaTime);
    }
}
