using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class FadingScreen : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CutSceneOldLady cutSceneOldLady;
    [SerializeField] CutsceneTakedaChangeShift cTCS;
    
    [SerializeField] GameObject oldLady;
    [SerializeField] GameObject takedaChangeShift;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float timeToShowText;
    [SerializeField] float fadeSpeed;

    bool fadeIn;
    bool fadeOut;

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
                    fadeIn = false;

                    if (!QuestCheck.isPlayedC3 && cutSceneOldLady != null)
                    {
                        text.text = "เวลาผ่านไป.."; // เปลี่ยนข้อความ
                        text.enabled = true;
                        StartCoroutine(WaitCutSceneC3());
                    }
                    if(!QuestCheck.isPlayedC4 && QuestCheck.isPlayedC3)
                    {
                        
                        text.text = "หลังจากนั้นไม่นาน"; // เปลี่ยนข้อความ
                        text.enabled = true;
                        StartCoroutine(WaitCutSceneC4());
                    }
                }
            }
        }


        if (fadeOut == true)
            if (canvasGroup.alpha >= 0)
            {
                StartCoroutine(WaitForInstantiateNPC()); // แสดง NPC ก่อนออกจอดำ
                text.enabled = false;
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }

    }

    IEnumerator WaitCutSceneC3()
    {
        yield return new WaitForSeconds(timeToShowText);
        cutSceneOldLady.CutScenePlay();
        yield return new WaitForSeconds(3f);
        fadeOut = true;
    }
    IEnumerator WaitCutSceneC4()
    {
        yield return new WaitForSeconds(timeToShowText);
        cTCS.CutScenePlay();
        yield return new WaitForSeconds(3f);
        fadeOut = true;
    }

    IEnumerator WaitForInstantiateNPC()
    {
        if(!QuestCheck.questTalkOldLady)
        {
            oldLady.SetActive(true);
            
        }
        
        if(QuestCheck.questTalkOldLady && !QuestCheck.questTalkTakeda_inSuperMarket)
        {
            takedaChangeShift.SetActive(true);
        }

        yield return new WaitForSeconds(3f);
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