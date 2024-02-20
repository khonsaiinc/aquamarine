using UnityEngine;
public class SetVase : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject NPC;

    void Start()
    {
        CheckBox();
    }

    public void GetBox()
    {
        box.SetActive(true);
        QuestCheck.getBox = true;
    }

    public void NPCDestroy()
    {
        Destroy(NPC);
    }

    public void CheckBox()
    {
        if (QuestCheck.questDelivery && QuestCheck.getBox)
        {
            box.SetActive(true);
        }
        else
        {
            box.SetActive(false);
        }
    }
}
