using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    public Dialogue dialogueAsset;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image portraitCharacter;
    [SerializeField] GameObject dialoguePanel;

    int dialogueQueue;

    public void ShowDialogue() //แสดงหน้าต่างข้อความ
    {
        nameText.text = dialogueAsset.nameCharacter;
        portraitCharacter.sprite = dialogueAsset.spriteCharacter;
        dialogueText.text = dialogueAsset.dialogue[dialogueQueue];
        dialoguePanel.SetActive(true);
    }

    public void EndDialogue() //ปิดหน้าต่างข้อความ
    {
        nameText.text = null;
        dialogueText.text = null;
        dialoguePanel.SetActive(false);
    }

    public void NextDialogue()
    {
        nameText.text = null;
        portraitCharacter.sprite = null;
        dialogueText.text = null;

        dialogueQueue += 1;
        if(dialogueQueue >= dialogueAsset.dialogue.Length)
        {
            EndDialogue();
            return;
        }

        ShowDialogue();

        
    }
    
}
