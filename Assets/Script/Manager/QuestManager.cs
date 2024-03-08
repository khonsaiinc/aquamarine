using TMPro;
using UnityEngine;
    public class QuestManager : MonoBehaviour
    {
        [Header("DialoguePanel")]
        [SerializeField] GameObject dialoguePanel;
        [Header("Text")]
        [SerializeField] TextMeshProUGUI questText;
        string mainText;
        string descriptText;

        void Start() 
        {
            UpdateQuestText();
        }

        public void UpdateQuestText()
        {
            questText.text = mainText + " : " + descriptText;
        }

    }