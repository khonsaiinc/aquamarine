using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BedSleep : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] FaderScreen faderScreen;
    [SerializeField] BoxCollider2D bedTrigger;
    [SerializeField] TextAsset inkJSON;
    [SerializeField] DialogueTalking afterTalking;

    bool playerInRange;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                SleepNow();
            }
        }
    }

    void Start()
    {
        if (!QuestCheck.questTalkTakeda_inSuperMarket)
        {
            bedTrigger.enabled = false;
        }
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

    public void SleepNow()
    {
        bedTrigger.enabled = false;
        StartCoroutine(NeighborEvent());
    }

    IEnumerator NeighborEvent()
    {
        faderScreen.FadeIn();
        yield return new WaitForSeconds(faderScreen.fadeSpeed + 3f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON,afterTalking);
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
