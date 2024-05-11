using UnityEngine;

public class NPCSwapController : MonoBehaviour {
    
    [Header("NPC Object Outside")]
    [SerializeField] GameObject Day1;
    [SerializeField] GameObject Day2;

    [Header("Night Object")]
    [SerializeField] GameObject Night1;
    [SerializeField] GameObject Night2;
    [SerializeField] GameObject Night3;

    [Header("Other object")]
    [SerializeField] GameObject lemonadeSellPeople;

    void Update() {
        checkquest();
    }

    void checkquest(){
        // TODO need to swap npc people, change script, and swap all npc in day,night
    if (QuestCheck.orderQuest == 0 ||QuestCheck.orderQuest == 1 || QuestCheck.orderQuest == 2 || QuestCheck.orderQuest == 3) {
        npcObjectDayEnabledNight1();
    }
    else if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8) {
        DisableAllNPCObjects();
        npcObjectDayEnabledDay1();
        }
    else if (QuestCheck.orderQuest == 10 || QuestCheck.orderQuest == 11 || QuestCheck.orderQuest == 12) {
        DisableAllNPCObjects();
        npcObjectDayEnabledNight2();
    }
    else if (QuestCheck.orderQuest == 15 || QuestCheck.orderQuest == 16 || QuestCheck.orderQuest == 17) {
        DisableAllNPCObjects();
        npcObjectDayEnableDay2();
    }
    else if (QuestCheck.orderQuest == 18 || QuestCheck.orderQuest == 19 || QuestCheck.orderQuest == 20 ||
    QuestCheck.orderQuest == 21 || QuestCheck.orderQuest == 22) {
        DisableAllNPCObjects();
        npcObjectDayEnabledNight3();
    }
    }
    void DisableAllNPCObjects() {
        npcObjectDisableDay1();
        npcObjectDisableDay2();
        npcObjectDisableNight1();
        npcObjectDisableNight2();
        npcObjectDisableNight3();
        Debug.Log("npc object has reseted");
    }

    #region NPC Day Time (include disable/enable)
    void npcObjectDayEnabledDay1() {
        Day1.SetActive(true);
    }

    void npcObjectDayEnableDay2() {
        Day2.SetActive(true);
    }

    void npcObjectDisableDay1() {
        Day1.SetActive(false);
    }

    void npcObjectDisableDay2() {
        Day2.SetActive(false);
    }
    #endregion

    #region NPC Night Time (include disable/enable)
    void npcObjectDayEnabledNight1() {
        Night1.SetActive(true);
    }

    void npcObjectDayEnabledNight2() {
        Night2.SetActive(true);
    }

    void npcObjectDayEnabledNight3() {
        Night3.SetActive(true);
    }

    void npcObjectDisableNight1() {
        Night1.SetActive(false);
        Debug.Log("Night 1 NPC object disabled");
    }

    void npcObjectDisableNight2() {
        Night2.SetActive(false);
        Debug.Log("Night 2 NPC object disabled");
    }

    void npcObjectDisableNight3() {
        Night3.SetActive(false);
        Debug.Log("Night 3 NPC object disabled");
    }
    #endregion
    }