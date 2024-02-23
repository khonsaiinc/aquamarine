using UnityEngine;
using UnityEngine.InputSystem;


public class CashierCounter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform standHere;
    [SerializeField] GameObject interactIcon;

    [SerializeField] TMPCanvas tMPCanvas;
    [SerializeField] OldLadyTalking oldLadyTalking;

    bool playerInRange;
    bool isEnterCashier;

    public bool isTalkOldLady;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                EnterCashier();
            }
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (!isEnterCashier)
            {
                interactIcon.SetActive(true);
            }
            else
            {
                interactIcon.SetActive(false); // เข้าไปแล้วให้ปิด interactIcon
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

        isTalkOldLady = oldLadyTalking.oldladyStillHere;
        if(isTalkOldLady && oldLadyTalking != null)
        {
            playerController.enabled = false;
        }
    }
    void EnterCashier()
    {
        if (!isEnterCashier)
        {

            player.GetComponent<SpriteRenderer>().sortingOrder = -2;
            player.transform.position = standHere.position;
            isEnterCashier = true;
            playerController.enabled = false;
            if (!QuestCheck.isPlayedC3)
            {
                tMPCanvas.FadeIn();
            }
        }
        else
        {
                if (QuestCheck.questTalkOldLady)
                {
                    player.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    isEnterCashier = false;
                    if (isTalkOldLady && oldLadyTalking == null)
                    {
                        isTalkOldLady = false;
                        playerController.enabled = true;
                    }
                    playerController.enabled = true;
                }
        }



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

