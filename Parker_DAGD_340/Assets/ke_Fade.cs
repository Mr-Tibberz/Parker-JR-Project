using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a simple script for fading in and then out an image.
/// The fade out time should be greater than the
/// </summary>
public class ke_Fade : MonoBehaviour {

    /// <summary>
    /// The plain white background.
    /// </summary>
    public Image mainImage;
    /// <summary>
    /// This is the RawImage object.
    /// </summary>
    public RawImage image;
    /// <summary>
    /// This is the amount of time until the fade in begins.
    /// </summary>
    public float timeUntilFadeIn;
    /// <summary>
    /// This is the amount of time the fade in will last.
    /// </summary>
    public float fadeInDuration;
    /// <summary>
    /// This is the amount of time until fade out.
    /// The pause duration between fading in and fading back out is timeUntilFadeOut - (fadeInDuration + timeUntilFadeIn).
    /// </summary>
    public float timeUntilFadeOut;
    /// <summary>
    /// This is the amount of time fading out takes.
    /// </summary>
    public float fadeOutDuration;
    /// <summary>
    /// This is the ratio between the durations and the times. Used to calculate the alpha of the object.
    /// </summary>
    public float ratio;
    /// <summary>
    /// The amount of time fading in has been running.
    /// </summary>
    private float fadeInTime;
    /// <summary>
    /// The amount of time fading out has been running.
    /// </summary>
    private float fadeOutTime;



    /// <summary>
    /// Runs once at runtime.
    /// </summary>
    void Start ()
    {
        fadeInTime = 0;
        fadeOutTime = fadeOutDuration;
    }
    /// <summary>
    /// Runs once everyframe.
    /// </summary>
	void Update ()
    {
        if (timeUntilFadeIn > 0)
        {
            timeUntilFadeIn -= Time.deltaTime;
        }
        if (timeUntilFadeOut > 0)
        {
            timeUntilFadeOut -= Time.deltaTime;
        }

        if (timeUntilFadeIn <= 0 && fadeInTime < fadeInDuration) FadeIn();
        else if (timeUntilFadeOut <= 0 && fadeOutTime > 0) FadeOut();
              
        image.color = new Color(255, 255, 255, ratio);
    }
    /// <summary>
    /// Changes the ratio starting at 0 and moving to 1.
    /// </summary>
    private void FadeIn ()
    {
        fadeInTime += Time.deltaTime;
        ratio = fadeInTime / fadeInDuration;
    }
    /// <summary>
    /// Changes the ratio starting at 1 and moving to 0.
    /// </summary>
    private void FadeOut ()
    {
        fadeOutTime -= Time.deltaTime;
        ratio = fadeOutTime / fadeOutDuration;

       mainImage.color = new Color(255, 255, 255, ratio);
    }
}
