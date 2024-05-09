using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {
    public void loadGameSceneFirst(){
        AudioManager.instance.PlaySFX("mouseclick");
        SceneManager.LoadScene("Room");
        Debug.Log("Clicked");
    }

    public void soundManagement(){
        // * need to do it, @room25552555, it's for main menu need to disable here
    }

    public void exitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Application Exiting..");
        #else
            Application.Quit();
            Debug.Log("Application Exit..");
        #endif
    }

    #region resetQuest
    void resetQuest(){
        Debug.Log("reset quested");
        QuestCheck.orderQuest = 0;
        QuestCheck.fistStarted = false;
        QuestCheck.questDelivery = false;
        QuestCheck.questTalkTakeda = false;
        QuestCheck.questTalkOldLady = false;
        QuestCheck.questTalkTakeda_inSuperMarket = false;
        QuestCheck.questGoToSleep = false;
        QuestCheck.questCheckWakeUpDay2 = false;
        QuestCheck.questTalkTakedaDay2 = false;
        
        // *reset outfit
        QuestCheck.canChangeOutfit = true;
        QuestCheck.outFit = "BrownPajama";
    }
    #endregion
}