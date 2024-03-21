using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    PlayerController playerController;

    /* The `#if UNITY_EDITOR` preprocessor directive in C# is used to conditionally compile code based on
    whether the code is being compiled in the Unity Editor or not. */
    #if UNITY_EDITOR
        public bool isPaused = false;
    #else
        bool isPaused = false;
    #endif

    public void Start() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isPaused = false; 
    }
    void Update() {
        if (playerController.pauseGameCheck)
        {
            PauseGame();
        }
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}