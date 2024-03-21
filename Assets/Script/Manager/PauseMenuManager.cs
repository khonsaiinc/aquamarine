using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject firstSelectedButton;
    public PlayerController playerController;
    public DontMoveGlobal dontMoveGlobal;

    static bool isPaused {get; set;}

    public void Start()
    {
        isPaused = false;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            StartCoroutine(DelayPause());
        }
        if (!isPaused)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        StopAllCoroutines();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        dontMoveGlobal.PlayerCanMove(false);
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        Time.timeScale = 0f;
        isPaused = true;
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
            isPaused = true;
        }
    }

    public void OnResumeGame(InputAction.CallbackContext context)
    {
        if (context.performed) // Check if paused first
        {
            isPaused = false;
        }
    }
}
