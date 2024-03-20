using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {
    public void loadGameSceneFirst(){
        SceneManager.LoadScene("Room");
    }

    public void soundManagement(){
        // sound here
    }

    public void exitGame(){
        Debug.Log("application exiting...");
        Application.Quit();
    }
}