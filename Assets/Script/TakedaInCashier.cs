using UnityEngine;

public class TakedaInCashier : MonoBehaviour
{
    [SerializeField] GameObject takedaNPC;
    [SerializeField] GameObject cashierCounterReal;
    [SerializeField] GameObject cashierCounterFake;

    void Start()
    {
        takedaNPC.SetActive(false);
        if (QuestCheck.orderQuest >= 6 && QuestCheck.orderQuest <= 8 || QuestCheck.orderQuest >= 15 && QuestCheck.orderQuest <= 17)
        {
            takedaNPC.SetActive(true);
            cashierCounterFake.SetActive(true);
            cashierCounterReal.SetActive(false);
        }
        else { Destroy(gameObject); }
    }
}

