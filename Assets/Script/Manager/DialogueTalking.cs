using UnityEngine;
using UnityEngine.Playables;

public class DialogueTalking : MonoBehaviour
{
    // ไว้ใช้ใน EXTERNAL
    public SetVase setVase;
    public TakedaOutside takedaOutside;
    public OldLadyTalking oldLadyTalking;
    public DisableTalking disableTalking;
    public SurveyEvent surveyEvent;
    public ChangeOutfit changeOutfit;
    public TakedaOutsideDay2 takedaOutsideDay2;
    public DontMoveGlobal dontMoveGlobal;
    public DialogueInTimeline dialogueInTimeline;
    public PlayableDirector timelineToPlay;
    void Start()
    {
        if (setVase == null)
            return;
        if (takedaOutside == null)
            return;
        if (oldLadyTalking == null)
            return;
        if (disableTalking == null)
            return;
        if (surveyEvent == null)
            return;
        if (changeOutfit == null)
            return;
        if (takedaOutsideDay2 == null)
            return;
        if (dontMoveGlobal == null)
            return;
        if (dialogueInTimeline == null)
            return;
        if (timelineToPlay == null)
            return;
    }
}

