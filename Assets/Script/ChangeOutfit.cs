using UnityEngine;
using UnityEngine.InputSystem;


public class ChangeOutfit : MonoBehaviour
{
    [SerializeField] BoxCollider2D wardrobeTrigger;
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
                if (QuestCheck.questDelivery)
                {
                    playerController.HinaChangeOutfit("WorkUniform");
                    wardrobeTrigger.enabled = false;
                    QuestCheck.canChangeOutfit = false;
                }
            }
        }
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (QuestCheck.canChangeOutfit)
        {
            WardrobeOpen();
        }
        else
        {
            wardrobeTrigger.enabled = false;
        }



    }

    public void WardrobeOpen()
    {
        if (QuestCheck.canChangeOutfit)
        {
            wardrobeTrigger.enabled = true;
        }
    }

    #region IconShow
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
