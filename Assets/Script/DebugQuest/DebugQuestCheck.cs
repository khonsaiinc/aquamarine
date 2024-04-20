using UnityEngine;

public class DebugQuestCheck : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] NameOutfit nameOutfit;

    [SerializeField][Range(0, 21)] int QuestOrder;

    [SerializeField] bool v1 = QuestCheck.isPlayedC1;
    [SerializeField] bool v2 = QuestCheck.isPlayedC2;
    [SerializeField] bool v3 = QuestCheck.isPlayedC3;
    [SerializeField] bool v4 = QuestCheck.isPlayedC4;
    [SerializeField] bool coffee = QuestCheck.isPlayedCoffe;


    void Start()
    {
        nameOutfit = NameOutfit.BrownPajama;
        QuestOrder = QuestCheck.orderQuest;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        switch (nameOutfit)
        {
            case NameOutfit.BrownPajama:
                playerController.HinaChangeOutfit("BrownPajama");
                QuestCheck.outFit = "BrownPajama";
                break;
            case NameOutfit.YellowPajama:
                playerController.HinaChangeOutfit("YellowPajama");
                QuestCheck.outFit = "YellowPajama";
                break;
            case NameOutfit.WorkUniform:
                playerController.HinaChangeOutfit("WorkUniform");
                QuestCheck.outFit = "WorkUniform";
                break;
            case NameOutfit.WorkUniform_HoldingBox:
                playerController.HinaChangeOutfit("WorkUniform_HoldingBox");
                QuestCheck.outFit = "WorkUniform_HoldingBox";
                break;
        }

        QuestCheck.orderQuest = QuestOrder;
        Debug.Log(QuestCheck.orderQuest);
        Debug.Log(QuestCheck.outFit);

        QuestCheck.isPlayedC1 = v1;
        QuestCheck.isPlayedC2 = v2;
        QuestCheck.isPlayedC3 = v3;
        QuestCheck.isPlayedC4 = v4;
        QuestCheck.isPlayedCoffe = coffee;


    }

}

public enum NameOutfit
{
    BrownPajama,
    YellowPajama,
    WorkUniform,
    WorkUniform_HoldingBox
}