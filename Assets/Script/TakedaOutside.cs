using UnityEngine;


public class TakedaOutside : MonoBehaviour
{
    [SerializeField] GameObject doorSuperMarket;
    [SerializeField] GameObject triggerTakeda;
    void Start()
    {
        if(QuestCheck.questTalkTakeda){
            Destroy(gameObject);
        }else{doorSuperMarket.SetActive(false);}
    }

    public void isTalkedEnableDoor()
    {
        if(QuestCheck.questTalkTakeda){
            triggerTakeda.SetActive(false);
            doorSuperMarket.SetActive(true);
        }
    }
}
