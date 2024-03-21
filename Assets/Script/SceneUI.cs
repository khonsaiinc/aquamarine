using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {
    public void loadGameSceneFirst(){
        SceneManager.LoadScene("Room");
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
}