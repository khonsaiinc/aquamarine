using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class TMPCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CutSceneOldLady cutSceneOldLady;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float timeToShowText;
    [SerializeField] float fadeSpeed;

    public bool fadeIn;
    public bool fadeOut;

    void Start()
    {
        text.enabled = false;
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (fadeIn == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    text.enabled = true;
                    fadeIn = false;
                    if (cutSceneOldLady != null)
                    {
                        StartCoroutine(WaitMoment());
                    }
                }
            }
        }


        if (fadeOut == true)
            if (canvasGroup.alpha >= 0)
            {
                text.enabled = false;
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }

    }

    IEnumerator WaitMoment()
    {
        yield return new WaitForSeconds(timeToShowText);
        cutSceneOldLady.CutScenePlay();
        yield return new WaitForSeconds(3f);
        fadeOut = true;
    }

    public void FadeIn()
    {
        fadeIn = true;
    }
    public void FadeOut()
    {
        fadeOut = true;
    }
}