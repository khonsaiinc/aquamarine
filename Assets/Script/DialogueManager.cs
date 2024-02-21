using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI displayNameText;
    [SerializeField] Animator portaitAnimator;

    [Header("Choice UI")]
    [SerializeField] GameObject[] choices;
    TextMeshProUGUI[] choicesText;

    Story currentStory;
    public bool dialogueIsPlaying{get;set;}

    static DialogueManager instance;

    // for disable input when dialogue is playing
    public PlayerController playerController; // import playercontroller from Assets\Script\PlayerController.cs

    InkExternalFunctions inkExternalFunctions;
    const string SPEAKER_TAG = "character";
    const string PORTRAIT_TAG = "image";

    void Awake()
    {
        if(instance != null)
        {
            
        }
        instance = this;

        inkExternalFunctions = new InkExternalFunctions();

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

        /*if(currentStory.currentChoices.Count == 0 && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            ContinueStory();
        }*/
    }

    public void Continue(InputAction.CallbackContext context)
    {
        if (currentStory.currentChoices.Count == 0 && context.performed)
        {
            Debug.Log("Click");
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON , DialogueTalking afterTalking)
    {
        DisablePlayerInput();
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        inkExternalFunctions.Bind(currentStory,afterTalking);

        displayNameText.text = "???";
        portaitAnimator.Play("default");

        ContinueStory();
    }
    void ContinueStory()
    {
        if(currentStory.canContinue)
        {

            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
            
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length !=2)
            {
                Debug.LogError("Tag have more 1");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portaitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag not current");
                    break;
            }
        }
    }

    IEnumerator ExitDialogueMode()
    {
        Debug.Log("End Dialogue");

        EnablePlayerInput();
        yield return new WaitForSeconds(0.2f);

        inkExternalFunctions.Unbind(currentStory);

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

    void EnablePlayerInput()
    {
        playerController.enabled = true;
    }
    void DisablePlayerInput()
    {
        playerController.enabled = false;
    }
}