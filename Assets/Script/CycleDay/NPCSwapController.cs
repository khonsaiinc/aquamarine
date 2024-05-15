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
    [SerializeField] GameObject TruckCar;

    [Header("Stalker Day")]
    [SerializeField] GameObject StalkerDay2;
    [SerializeField] GameObject StalkerDay3;

    void Update() {
        checkquest();
    }

    void checkquest(){
    // *Night 1
    if (QuestCheck.orderQuest == 0 ||QuestCheck.orderQuest == 1 || QuestCheck.orderQuest == 2 || QuestCheck.orderQuest == 3) {
        npcObjectDayEnabledNight1();
    }
    // * Day 1
    else if (QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7 || QuestCheck.orderQuest == 8) {
        Destroy(Night1);
        npcObjectDayEnabledDay1();
        truckCarEnable();
    }
    // * Night 2
    else if (QuestCheck.orderQuest == 10 || QuestCheck.orderQuest == 11 || QuestCheck.orderQuest == 12) {
        Destroy(Day1);
        npcObjectDayEnabledNight2();
        truckCarDisable();
    }
    // * Day 2
    else if (QuestCheck.orderQuest == 15 || QuestCheck.orderQuest == 16 || QuestCheck.orderQuest == 17) {
        Destroy(StalkerDay2);
        Destroy(Night2);
        npcObjectDayEnableDay2();
    }
    // * Night 3
    else if (QuestCheck.orderQuest == 18 || QuestCheck.orderQuest == 19 || QuestCheck.orderQuest == 20 ||
    QuestCheck.orderQuest == 21 || QuestCheck.orderQuest == 22) {
        Destroy(Day2);
        npcObjectDayEnabledNight3();
        truckCarEnable();
    }
    }
    void truckCarEnable() {
        TruckCar.SetActive(true);
    }
    void truckCarDisable() {
        TruckCar.SetActive(false);
    }

    #region NPC Day Time (include disable/enable)
    void npcObjectDayEnabledDay1() {
        Day1.SetActive(true);
    }

    void npcObjectDayEnableDay2() {
        Day2.SetActive(true);
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
    #endregion
    }