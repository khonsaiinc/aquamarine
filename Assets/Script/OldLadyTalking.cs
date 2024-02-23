using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class OldLadyTalking : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] BoxCollider2D boxColliderDialogueTrigger;
    [SerializeField] PlayerController playerController;
    //[SerializeField] CashierCounter cashierCounter;

    public bool oldladyStillHere;

    void Start()
    {
        if(QuestCheck.questTalkOldLady)
        {
            oldladyStillHere = false;
            Destroy(gameObject);
        }
    }

    public void moveOldlady()
    {
        oldladyStillHere = false;
        playableDirector.Play();
    }

    public void ClearOldlady()
    {
        Destroy(gameObject);
    }
}

