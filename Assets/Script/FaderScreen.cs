using TMPro;
using UnityEngine;


public class FaderScreen : MonoBehaviour
{
    // ใช้งานทั่วไป
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField]  public float fadeSpeed;

    [Header("PlayerControllGlobal")]
    [SerializeField] DontMoveGlobal dontMoveGlobal;

    bool fadeIn;
    bool fadeOut;

    void Start()
    {
        text.text = "";
        text.enabled = false;
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (fadeIn == true)
        {
            dontMoveGlobal.PlayerCanMove(false);
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            
            if (canvasGroup.alpha >= 0)
            {
                text.enabled = false;

                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    dontMoveGlobal.PlayerCanMove(true);
                    fadeOut = false;
                }
            }
        }

    }

    #region FadeSate

    public void FadeIn()
    {
        fadeIn = true;
    }
    public void FadeOut()
    {
        fadeOut = true;
    }

    #endregion
}