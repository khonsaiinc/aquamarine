using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger1 : MonoBehaviour
{
    [Header("Interact Icon")]
    [SerializeField] GameObject interactIcon;

    [Header("Ink Json")]
    [SerializeField] TextAsset inkJSON;
    [Header("DialogueTalking")]
    [SerializeField] DialogueTalking afterTalking;
    bool playerInRange;


    void Awake()
    {
        playerInRange = false;
        interactIcon.SetActive(false);
    }

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            interactIcon.SetActive(true);
            if(context.performed)
            {
                //playerPos.position = new Vector2(standHere.position.x,playerPos.position.y);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON,afterTalking);
            }
        }
    }

    void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
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
        if(collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
