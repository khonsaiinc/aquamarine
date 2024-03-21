using UnityEngine;

public class DialogueTalking : MonoBehaviour
{
    // ไว้ใช้ใน EXTERNAL
    public SetVase setVase;
    public TakedaOutside takedaOutside;
    public OldLadyTalking oldLadyTalking;
    public DisableTalking disableTalking;
    public SurveyEvent surveyEvent;
    public ChangeOutfit changeOutfit;
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
    }
}

