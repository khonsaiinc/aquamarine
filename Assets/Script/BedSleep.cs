using UnityEngine;
using UnityEngine.InputSystem;

public class BedSleep : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] FaderScreen faderScreen;

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
            gameObject.SetActive(false);
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
        faderScreen.FadeIn();
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
