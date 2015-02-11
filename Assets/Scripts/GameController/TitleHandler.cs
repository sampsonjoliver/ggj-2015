using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleHandler : MonoBehaviour
{
    public float fadeInTime = 4f;
    bool displayingStartText;
    public Text startText;
    private string levelName = "basics";
    public float timer = 0f;
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (!displayingStartText && timer >= fadeInTime)
        {
            startText.enabled = true;
            displayingStartText = true;
        }

        if (displayingStartText)
        {
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.LoadLevel(levelName);
            }
        }
	}
}
