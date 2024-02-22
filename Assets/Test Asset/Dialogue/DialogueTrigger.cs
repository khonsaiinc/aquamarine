using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Interact Icon")]
    [SerializeField] GameObject interactIcon;

    [Header("Ink Json")]
    [SerializeField] TextAsset inkJSON;

    [Header("Vase")]
    [SerializeField] DialogueTalking afterTalking;
    bool playerInRange;

    void Awake()
    {
        playerInRange = false;
        interactIcon.SetActive(false);
    }

    void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            interactIcon.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON,afterTalking);
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
