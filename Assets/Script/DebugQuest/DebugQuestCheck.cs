using UnityEngine;

public class DebugQuestCheck : MonoBehaviour
{
    [SerializeField] NameOutfit nameOutfit;
    PlayerController playerController;

    [SerializeField][Range(0,11)] int QuestOrder;
    void Start()
    {
        nameOutfit = NameOutfit.BrownPajama;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        switch(nameOutfit)
        {
            case NameOutfit.BrownPajama :
            playerController.HinaChangeOutfit("BrownPajama");
            break;
            case NameOutfit.YellowPajama :
            playerController.HinaChangeOutfit("YellowPajama");
            break;
            case NameOutfit.WorkUniform :
            playerController.HinaChangeOutfit("WorkUniform");
            break;
            case NameOutfit.WorkUniform_HoldingBox :
            playerController.HinaChangeOutfit("WorkUniform_HoldingBox");
            break;
        }
        
        QuestCheck.orderQuest = QuestOrder;
        Debug.Log(QuestCheck.orderQuest);
        
    }

}

public enum NameOutfit
{
    BrownPajama,
    YellowPajama,
    WorkUniform,
    WorkUniform_HoldingBox
}

