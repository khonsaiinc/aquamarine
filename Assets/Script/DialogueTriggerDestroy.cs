/* This C# script is a DialogueTriggerDestroy class that triggers dialogue when a player enters a
collider, with the ability to disable itself based on a quest check. */

using UnityEngine;
public class DialogueTriggerDestroy : MonoBehaviour
{
    [Header("Ink Json")]
    [SerializeField] TextAsset inkJSON;
    [Header("DialogueTalking")]
    [SerializeField] DialogueTalking afterTalking;
    bool playerInRange;
    
    private void Start() {
        if (QuestCheck.objectcheck == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON,afterTalking);
        }
    }

    public void disableObject (){
        Destroy(gameObject);
    }
}
