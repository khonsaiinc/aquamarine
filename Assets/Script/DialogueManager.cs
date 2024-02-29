using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    public static bool OnDialogueMode = false;
    private bool canShowDialogue = true;

    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI displayNameText;
    [SerializeField] Animator portaitAnimator;
    [SerializeField] Transform targetTranform;
    [SerializeField] Transform targetExitTranform;
    [SerializeField] float duration;

    [Header("Choice UI")]
    [SerializeField] GameObject[] choices;
    TextMeshProUGUI[] choicesText;

    Story currentStory;
    public bool dialogueIsPlaying { get; set; }

    static DialogueManager instance;

    // for disable input when dialogue is playing
    public PlayerController playerController; // import playercontroller from Assets\Script\PlayerController.cs
    public PlayerInput playerInput;

    InkExternalFunctions inkExternalFunctions;
    const string SPEAKER_TAG = "character";
    const string PORTRAIT_TAG = "image";

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("DialogueManager have more than one instance");
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
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        /*if(currentStory.currentChoices.Count == 0 && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            ContinueStory();
        }*/
    }

    IEnumerator continueDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ContinueStory();
    }
    public void Continue(InputAction.CallbackContext context)
    {
        if (currentStory != null && currentStory.currentChoices.Count == 0
        && context.performed)
        {
            Debug.Log("Continue");
            StartCoroutine(continueDelay());
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON, DialogueTalking afterTalking)
    {
        Debug.Log("EnterDialogueMode");
        OnDialogueMode = true;
        DisablePlayerInput();
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        LeanTween.moveY(dialoguePanel, targetTranform.position.y, duration);

        inkExternalFunctions.Bind(currentStory, afterTalking);

        displayNameText.text = "???";
        portaitAnimator.Play("default");

        StartCoroutine(continueDelay());
    }
    void ContinueStory()
    {
        if (!canShowDialogue)
            return;

        if (currentStory.canContinue)
        {
            Debug.Log("ContinueStory");
            canShowDialogue = false;
            StartCoroutine(DialogueDelay());
            dialogueText.text = currentStory.Continue();
            DisplayChoices();

            string nextLine = dialogueText.text;

            if(nextLine.Equals("") && !currentStory.canContinue)
            {
                StartCoroutine(ExitDialogueMode());
            }
            else
            {
                HandleTags(currentStory.currentTags);
            }
            
        }
        else
        {
            Debug.Log("Story Ended");
            StartCoroutine(ExitDialogueMode());
        }
    }

    void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag have more 1");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
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
        LeanTween.moveY(dialoguePanel, targetExitTranform.position.y, duration);

        yield return new WaitForSeconds(1f);

        EnablePlayerInput();

        inkExternalFunctions.Unbind(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        StopAllCoroutines(); // disable all coroutine, it's maybe work?
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;


        //ตรวจว่าตัวเลือกมีมากกว่าปุ่มUIของตัวเลือกรีเปล่า
        if (currentChoices.Count > choices.Length)
        {
            Debug.Log("More choice were given than the UI can suppport. Number of choices given:"
             + currentChoices);

        }

        //เพิ่มตัวเลือก
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }


        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);

        }

        //StartCoroutine(SelectFirstChoice());
    }

    /*IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }*/

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    void EnablePlayerInput()
    {
        playerController.enabled = true;
        playerInput.enabled = true;
    }
    void DisablePlayerInput()
    {
        playerController.enabled = false;
        playerInput.enabled = false;
    }

    IEnumerator DialogueDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canShowDialogue = true;
    }
}