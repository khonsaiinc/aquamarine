using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClockSpawn : MonoBehaviour
{
    [SerializeField] SpriteRenderer spritePos;
    [SerializeField] List<Sprite> clockTime = new List<Sprite>();


    int currentQuestOrder;

    void Update()
    {
        currentQuestOrder = QuestCheck.orderQuest;

        if (currentQuestOrder == 6
            || currentQuestOrder == 15)
        {
            spritePos.sprite = clockTime[0];//05:00
        }

        if (currentQuestOrder == 7
            || currentQuestOrder == 8
            || currentQuestOrder == 9
            || currentQuestOrder == 16
            || currentQuestOrder == 17)
        {
            spritePos.sprite = clockTime[1];//06:00
        }

        if (currentQuestOrder == 18
            || currentQuestOrder == 19)
        {
            spritePos.sprite = clockTime[2];//19:00
        }

        if (currentQuestOrder == 0
            || currentQuestOrder == 1
            || currentQuestOrder == 2
            || currentQuestOrder == 10
            || currentQuestOrder == 11
            || currentQuestOrder == 20)
        {
            spritePos.sprite = clockTime[3];//20:00
        }

        if (currentQuestOrder == 3
            || currentQuestOrder == 4
            || currentQuestOrder == 12)
        {
            spritePos.sprite = clockTime[4];//20:30
        }

        if (currentQuestOrder == 5)
        {
            spritePos.sprite = clockTime[5];//21:00
        }

        if (currentQuestOrder == 13
            || currentQuestOrder == 14
            || currentQuestOrder == 21)
        {
            spritePos.sprite = clockTime[6];//00:00
        }
    }
}
