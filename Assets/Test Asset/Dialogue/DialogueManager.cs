using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    [Header("Choice UI")]
    [SerializeField] GameObject[] choices;
    TextMeshProUGUI[] choicesText;

    Story currentStory;
    public bool dialogueIsPlaying{get;set;}

    static DialogueManager instance;

    void Awake()
    {
        if(instance != null)
        {
            
        }
        instance = this;

    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(currentStory.currentChoices.Count == 0 && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }
    void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    IEnumerator ExitDialogueMode()
    {
        Debug.Log("End Dialogue");
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text ="";
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //ตรวจว่าตัวเลือกมีมากกว่าปุ่มUIของตัวเลือกรีเปล่า
        if(currentChoices.Count > choices.Length)
        {
            Debug.Log("More choice were given than the UI can suppport. Number of choices given:"
             + currentChoices);
            
        }

        //เพิ่มตัวเลือก
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }


        for (int i = index; i < choices.Length;i++)
        {
            choices[i].gameObject.SetActive(false);

        }

        //StartCoroutine(SelectFirstChoice());
    }

    IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        //Input.GetMouseButtonDown(0);
        ContinueStory();
    }
}
