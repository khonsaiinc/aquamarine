using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class OldLadyTalking : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] PlayerController playerController;


    // สั่ง oldlady เดิน

    void Start()
    {
        if(QuestCheck.questTalkOldLady)
        {
            Destroy(gameObject);
        }
    }

    public void moveOldlady()
    {
        playableDirector.Play();
    }

    public void ClearOldlady()
    {
        Destroy(gameObject);
    }
}

