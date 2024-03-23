using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class OldLadyTalking : MonoBehaviour
{
    [SerializeField] PlayableDirector goOut;
    [SerializeField] PlayableDirector moveToCashier;
    [SerializeField] PlayerController playerController;



    // สั่ง oldlady เดิน

    void Start()
    {
        if(QuestCheck.questTalkOldLady)
        {
            Destroy(gameObject);
        }
    }

    public void moveOldlady() // เดินออกไปข้างนอก
    {
        goOut.Play();
    }

    public void moveOldladyToCashier()
    {
        moveToCashier.Play();
    }

    public void ClearOldlady()
    {
        Destroy(gameObject);
    }
}

