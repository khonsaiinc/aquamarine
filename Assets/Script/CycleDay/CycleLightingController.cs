using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleLightingController : MonoBehaviour
{
    [Header("Questorder For Light_Turnoff")]
    [SerializeField][Range(0, 11)] int orderQuest;
    [Header("LightInScene")]
    [SerializeField] List<GameObject> lightInScene = new List<GameObject>();

    void Start()
    {
        CheckForCycleLight();
    }

    void CheckForCycleLight()
    {
        if (QuestCheck.orderQuest == orderQuest)
        {
            for (int i = 0; i < lightInScene.Count; i++)
            {
                if (lightInScene[i].activeInHierarchy)
                {
                    lightInScene[i].SetActive(false);
                }
                else
                {
                    lightInScene[i].SetActive(true);
                }
            }
        }
    }




}