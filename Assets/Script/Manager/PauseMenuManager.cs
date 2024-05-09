using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject firstSelectedButton;
    public PlayerController playerController;
    public DontMoveGlobal dontMoveGlobal;

    static bool isPaused { get; set; }

    public void Start()
    {
        isPaused = false;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found!");
        }
        if (firstSelectedButton == null)
        {
            Debug.LogWarning("FirstSelectedButton not assigned!");
        }
        if (dontMoveGlobal == null)
        {
            Debug.LogWarning("DontMoveGlobal not assigned!");
        }
    }

    public void ResumeGame()
    {
        StopCoroutine(DelayPause());
        dontMoveGlobal.PlayerCanMove(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Game Resumed!");
    }

    public void PauseGame()
    {
        dontMoveGlobal.PlayerCanMove(false);
        pauseMenuUI.SetActive(true);
        // EventSystem.current.SetSelectedGameObject(firstSelectedButton); // *disable for now
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Game Paused!");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(0.1f);
        PauseGame();
        Debug.Log("Pause game Finished!");
    }

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGame();
        }
    }

    public void OnResumeGame(InputAction.CallbackContext context)
    {
        if (context.performed) // Check if paused first
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Debug.LogWarning("Game is not paused!");
            }
        }
    }
}
