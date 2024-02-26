using UnityEngine;

public class DialogueTalking : MonoBehaviour
{
    // ไว้ใช้ใน EXTERNAL
    public SetVase setVase;
    public TakedaOutside takedaOutside;
    public OldLadyTalking oldLadyTalking;
    public DisableTalking disableTalking;
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
    }
}

