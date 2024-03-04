using System.Collections;
using UnityEngine;

public class SurveyEvent : MonoBehaviour
{
    [SerializeField] GameObject doorReal;
    [SerializeField] GameObject doorSurvey;
    [SerializeField] FaderScreen faderScreen;
    [SerializeField] DontMoveGlobal playerController;
    
    void Start()
    {
        if(!QuestCheck.NeighborSurvey)
        {
            doorSurvey.SetActive(false);
        }
    }

    public void ContinueToSleep()
    {
        Debug.Log("Wake UP Day2");
        faderScreen.FadeOut();
    }


    public void StartNeighborSurveyEvent()
    {
        StartCoroutine(DoorNeighborSurvey());
    }

    IEnumerator DoorNeighborSurvey()
    {
        doorReal.SetActive(false);//ปิดประตูจริง
        doorSurvey.SetActive(true);//เปิดประตูออกไปดูข้างห้อง

        faderScreen.FadeOut();
        yield return new WaitForSeconds(faderScreen.fadeSpeed);
    }
}

