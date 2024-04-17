using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class CycleLightOutside : MonoBehaviour
{
    [Header("PostProcessingVolume")]
    [SerializeField] Volume volumePostPocessing;
    [SerializeField] List<VolumeProfile> volumeProfiles = new List<VolumeProfile>();
    [Header("GlobalLight")]
    [SerializeField] Light2D globalLight;
    [SerializeField] List<CycleLightingData> cycleLightingDatas = new List<CycleLightingData>();
    [Header("SkyBackground")]
    [SerializeField] List<GameObject> background = new List<GameObject>();
    [Header("Sunlight")]
    [SerializeField] Light2D sunlight;
    [Header("LightingObject")]
    [SerializeField] List<GameObject> LightingsInScene = new List<GameObject>();

    void Start()
    {
        CheckDayTime();

    }

    void CheckDayTime()
    {
        if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8
        || QuestCheck.orderQuest == 15 || QuestCheck.orderQuest == 16 || QuestCheck.orderQuest == 17)// ตอนเช้า
        {
            volumePostPocessing.profile = volumeProfiles[0];
            globalLight.intensity = cycleLightingDatas[0].intensityLight;
            SwichLightInScene();
            background[1].SetActive(false);

            sunlight.intensity = 0.4f;

            
        }
        else //ตอนกลางคืน
        {
            volumePostPocessing.profile = volumeProfiles[1];
            globalLight.intensity = cycleLightingDatas[1].intensityLight;
            background[0].SetActive(false);

            //sunlight.intensity = 0.3f;
        }
    }

    void SwichLightInScene()
    {
        if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8
        || QuestCheck.orderQuest == 15 || QuestCheck.orderQuest == 16 || QuestCheck.orderQuest == 17)
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
