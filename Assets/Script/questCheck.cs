//ไว้เก็บ true/false ต่างๆ ระหว่าง scenes
public static class QuestCheck
{
    public static bool fistStart{get;set;}
    public static bool questDelivery{get;set;}

    #region isCutscenePlayed
    public static bool isPlayedC1;
    public static bool isPlayedC2;
    #endregion

    #region Inventory

    public static bool getBox{get;set;}

    #endregion
}

