using UnityEngine;
using UnityEngine.Video;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;


public class CutsceneDeathHall : MonoBehaviour
{
    [Header("Video")]
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject screenVideo;
    [SerializeField] RenderTexture renderTexture;
    [Header("Canvas")]
    [SerializeField] GameObject deadScreen;
    [SerializeField] CanvasGroup canvasGroupBackground;
    [SerializeField] GameObject deadText;
    [SerializeField] CanvasGroup canvasGroupDeadText;
    [SerializeField] FaderScreen faderScreen;

    [Header("Icon")]
    [SerializeField] GameObject interactIcon;

    [Header("PlayerMoveGlobal")]
    [SerializeField] DontMoveGlobal dontMoveGlobal;
    bool playerInRange;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                StartCoroutine(DeathAtNeighborRoom());
            }
        }
    }

    void Start()
    {
         screenVideo.SetActive(false);
         deadScreen.SetActive(false);
         deadText.SetActive(false);
    }
    void Update()
    {
        if (playerInRange)
        {
            interactIcon.SetActive(true);
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

    IEnumerator DeathAtNeighborRoom()
    {
        dontMoveGlobal.PlayerCanMove(false);
        
        faderScreen.FadeIn();
        yield return new WaitForSeconds(faderScreen.fadeSpeed);

        screenVideo.SetActive(true);
        videoPlayer.Play();
        
        yield return new WaitForSeconds(3f);

        renderTexture.Release();

        deadScreen.SetActive(true);
        deadText.SetActive(true);
        canvasGroupBackground.LeanAlpha(1,2f);
        canvasGroupDeadText.LeanAlpha(1,5f);
    }

    #region CheckCollider Player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    #endregion
}
