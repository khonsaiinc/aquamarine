using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorLockEvent : MonoBehaviour
{
    [Header("Trigger")]
    [SerializeField] BoxCollider2D doorTrigger;
    [SerializeField] BoxCollider2D doorLockEventTrigger;

    [SerializeField] int currentGoodsInStock;
    [SerializeField] int maxGoodsInStock;

    private void Awake()
    {

    }

    void Start()
    {
        OnDoorLockEvent();
    }

    private void Update()
    {
        currentGoodsInStock = QuestManager.instance.currentGoodsInStock;
        maxGoodsInStock = QuestManager.instance.maxGoodsInStock;
        if (QuestCheck.isDoorlockEventPlayed == false)
        {
            OnDoorLockEvent();
        }


    }

    void OnDoorLockEvent()
    {
        // เควสยกกล่องวันที่ 2 และ เหลือเติมสินค้าชิ้นสุดท้าย และ Hinaต้องยกกล่อง
        if (QuestCheck.orderQuest == 12 && currentGoodsInStock == maxGoodsInStock - 1 && QuestCheck.outFit == "WorkUniform_HoldingBox")
        {
            doorTrigger.enabled = false;
            doorLockEventTrigger.enabled = true;
        }
        else
        {
            doorLockEventTrigger.enabled = false;
        }
    }
}

