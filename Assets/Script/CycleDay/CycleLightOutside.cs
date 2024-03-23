using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class CycleLightOutside : MonoBehaviour
{
    [SerializeField] Volume volumePostPocessing;
    [SerializeField] Light2D globalLight;
    [SerializeField] List<VolumeProfile> volumeProfiles = new List<VolumeProfile>();
    [SerializeField] List<CycleLightingData> cycleLightingDatas = new List<CycleLightingData>();
    [SerializeField] List<GameObject> LightingsInScene = new List<GameObject>(); 

    void Start()
    {
        CheckDayTime();

    }

    void CheckDayTime()
    {
        if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8)
        {
            volumePostPocessing.profile = volumeProfiles[0];
            globalLight.intensity = cycleLightingDatas[0].intensityLight;
            SwichLightInScene();
        }
        else
        {
            volumePostPocessing.profile = volumeProfiles[1];
            globalLight.intensity = cycleLightingDatas[1].intensityLight;
        }
    }

    void SwichLightInScene()
    {
        if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8)
        {
            for (int i = 0; i < LightingsInScene.Count; i++)
            {
                if (LightingsInScene[i].activeInHierarchy)
                {
                    LightingsInScene[i].SetActive(false);
                }
                else
                {
                    LightingsInScene[i].SetActive(true);
                }
            }
        }
    }
}
