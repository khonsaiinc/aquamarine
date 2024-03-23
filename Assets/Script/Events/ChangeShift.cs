using UnityEngine;

public class ChangeShift : MonoBehaviour
{
    [SerializeField] GameObject takedaChangeShift;

    void Start()
    {
        takedaChangeShift.SetActive(false);
        if(QuestCheck.questTalkTakeda_inSuperMarket)
        {
            Destroy(gameObject);
        }
    }


}

