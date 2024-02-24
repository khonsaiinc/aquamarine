using UnityEngine;
using UnityEngine.InputSystem;


public class CashierCounter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform standHere;
    [SerializeField] GameObject interactIcon;

    [SerializeField] TMPCanvas tMPCanvas;

    bool playerInRange;
    bool isEnterCashier;

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
            interactIcon.SetActive(true);
        }
        else
        {
            interactIcon.SetActive(false);
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
            tMPCanvas.FadeIn();

        }
        else
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 0;
            isEnterCashier = false;
            playerController.enabled = true;
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

