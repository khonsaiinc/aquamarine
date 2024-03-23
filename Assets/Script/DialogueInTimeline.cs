using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class DialogueInTimeline : MonoBehaviour
{
    [Header("Ink Json")]
    [SerializeField] TextAsset inkJSON;
    [Header("DialogueTalking")]
    [SerializeField] DialogueTalking afterTalking;
    [Header("HinaMoveTimeline")]
    [SerializeField] PlayableDirector hinaMoveTimeline;

    public void OnStartDialogue()
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON,afterTalking);
            hinaMoveTimeline.playableGraph.GetRootPlayable(0).Pause();
        }
    }

    public void OnEndDialogue()
    {
        hinaMoveTimeline.playableGraph.GetRootPlayable(0).Play();
    }
}

