using UnityEngine;

public class TakedaInCashier : MonoBehaviour
{
    [SerializeField] GameObject takedaNPC;
    [SerializeField] GameObject cashierCounterReal;
    [SerializeField] GameObject cashierCounterFake;

    void Start()
    {
        takedaNPC.SetActive(false);
        if(QuestCheck.questTalkTakeda_inSuperMarket)
        {
            if(!QuestCheck.questGoToSleep && QuestCheck.orderQuest == 6)
            {
                takedaNPC.SetActive(true);
                cashierCounterFake.SetActive(true);
                cashierCounterReal.SetActive(false);
            }
            else{Destroy(gameObject);}
        }
    }
}

