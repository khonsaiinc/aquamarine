using UnityEngine;

public class DebugQuestCheck : MonoBehaviour
{
    [SerializeField] NameOutfit nameOutfit;
    PlayerController playerController;

    [SerializeField][Range(0,20)] int QuestOrder;
    void Start()
    {
        nameOutfit = NameOutfit.BrownPajama;
        QuestOrder = QuestCheck.orderQuest;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        switch(nameOutfit)
        {
            case NameOutfit.BrownPajama :
            playerController.HinaChangeOutfit("BrownPajama");
            QuestCheck.outFit = "BrownPajama";
            break;
            case NameOutfit.YellowPajama :
            playerController.HinaChangeOutfit("YellowPajama");
            QuestCheck.outFit = "YellowPajama";
            break;
            case NameOutfit.WorkUniform :
            playerController.HinaChangeOutfit("WorkUniform");
            QuestCheck.outFit = "WorkUniform";
            break;
            case NameOutfit.WorkUniform_HoldingBox :
            playerController.HinaChangeOutfit("WorkUniform_HoldingBox");
            QuestCheck.outFit = "WorkUniform_HoldingBox";
            break;
        }
        
        QuestCheck.orderQuest = QuestOrder;
        Debug.Log(QuestCheck.orderQuest);
        Debug.Log(QuestCheck.outFit);
        
    }

}

public enum NameOutfit
{
    BrownPajama,
    YellowPajama,
    WorkUniform,
    WorkUniform_HoldingBox
}

