using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KeepBox : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] PlayerController playerController;

    bool playerInRange;
    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            interactIcon.SetActive(true);
            if (context.performed)
            {
                //เปลี่ยนชุด
                if (QuestCheck.isWorking)
                {
                    if (QuestCheck.outFit == "WorkUniform")
                    {
                        playerController.HinaChangeOutfit("WorkUniform_HoldingBox");
                    }
                    else if (QuestCheck.outFit == "WorkUniform_HoldingBox")
                    {
                        playerController.HinaChangeOutfit("WorkUniform");
                    }

                }
            }
        }
    }



    #region IconShow
    void Update()
    {
        if (QuestCheck.isWorking)
        {
            if (QuestCheck.outFit == "WorkUniform" || QuestCheck.outFit == "WorkUniform_HoldingBox")
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
            else
            {
                interactIcon.SetActive(false);
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

    }

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

