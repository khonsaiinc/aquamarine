//ไว้เก็บ true/false ต่างๆ ระหว่าง scenes
public static class QuestCheck
{
    public static bool fistStarted{get;set;}
    public static bool questDelivery{get;set;}
    public static bool questTalkTakeda{get;set;}
    public static bool questTalkOldLady{get;set;}
    public static bool questTalkTakeda_inSuperMarket{get;set;}
    public static bool questGoToSleep{get;set;}
    public static bool questCheckWakeUpDay2{get;set;}

    #region EventStoryCheck

    public static bool NeighborSurvey{get;set;} //ไว้ใช้เมื่อเลือกออกไปดูข้างห้อง
    public static bool isUnlockStorageRoom{get;set;} //ปลดล็อคประตูห้องเก็บของ

    #endregion EventStoryCheck

    #region isCutscenePlayed

    public static bool isPlayedC1;
    public static bool isPlayedC2;
    public static bool isPlayedC3;
    public static bool isPlayedC4;

    #endregion

    #region Scenebefore

    public static string sceneBefore = "";

    #endregion

    #region Inventory

    public static bool getBox{get;set;}
    public static bool isOpenBox{get;set;}
    public static bool isCloseBox{get;set;}

    #endregion
    
}

