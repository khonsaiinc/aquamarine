using UnityEngine;
public class SetVase : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject vase;
    [SerializeField] GameObject interactIcon;
    [SerializeField] GameObject dialogueBoxC5;

    bool playerInRange;
    bool isOpenBox;


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
        if (QuestCheck.isOpenBox)
        {
            vase.SetActive(true);
            Destroy(gameObject); // ถ้าเลือกเปิดกล่องให้ทำลายเมื่อเข้าออก Room ใน Day2
        }

        if(!QuestCheck.questTalkTakeda_inSuperMarket)
        {
            dialogueBoxC5.SetActive(false);
        }else
        {
            dialogueBoxC5.SetActive(true);
        }

        if (QuestCheck.questDelivery && QuestCheck.getBox)
        {
            box.SetActive(true);
        }
        else
        {
            box.SetActive(false);
        }
    }

    public void OpenBox()
    {
        if (QuestCheck.questTalkTakeda_inSuperMarket && !isOpenBox)
        {
            box.SetActive(false);
            QuestCheck.isOpenBox = true;
            vase.SetActive(true);
            Destroy(gameObject); // ทำลายถ้าเลือกเปิดกล่องใน C5.0
        }
    }
}
