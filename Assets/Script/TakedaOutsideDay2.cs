using System.Collections;
using UnityEngine;
using UnityEngine.Playables;


public class TakedaOutsideDay2 : MonoBehaviour
{
    [SerializeField] GameObject doorSuperMarket;
    [SerializeField] GameObject triggerTakeda;
    [SerializeField] PlayableDirector playableDirector;
    void Start()
    {
        if(QuestCheck.orderQuest != 11)
        {
            Destroy(gameObject);
        }

        if(QuestCheck.questTalkTakeda){
            Destroy(gameObject);
        }else{doorSuperMarket.SetActive(false);}
    }

    public void isTalkedEnableDoor()
    {
        if(QuestCheck.questTalkTakeda){
            triggerTakeda.SetActive(false);
            doorSuperMarket.SetActive(true);
        StartCoroutine(TakadaGoOutScene());
        }
    }

    IEnumerator TakadaGoOutScene()
    {
        yield return new WaitForSeconds(0.5f);
        playableDirector.Play();
    }
}
