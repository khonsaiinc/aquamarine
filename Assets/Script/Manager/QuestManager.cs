using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager instance { get; set; }

    [Header("SceneController")]
    [SerializeField] SceneController sceneController;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI questText;
    string mainText;
    string descriptText;
    [Header("DataQuest")]
    int orderQuest;
    [SerializeField] List<DataQuest> dataQuests = new List<DataQuest>();

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();

        orderQuest = QuestCheck.orderQuest; //โหลดลำดับเควสที่บันทึกไว้ เมื่อเริ่มซีน
        OnStartSceneQuestComplete();
    }

    void Update()
    {
        ShowQuestText();
    }

    public void ShowQuestText()
    {
        mainText = dataQuests[orderQuest].titleQuest;//เปลี่ยนหัวข้อเควส
        descriptText = dataQuests[orderQuest].informationQuest;//เปลี่ยนคำอธิบายเควส

        questText.text = mainText + " : " + descriptText;
    }

    public void OnCompleteQuest()
    {
        orderQuest++;
        QuestCheck.orderQuest = orderQuest; //บันทึกลำดับเควสให้ตัวกลาง
    }

    public void OnStartSceneQuestComplete()//เมื่อเริ่มซีนให้เควสเสร็จ เช่น ไปสถานที่ต่างๆ
    {
        if (QuestCheck.orderQuest == 2 && sceneController.currentScene == "SuperMarket")
        {
            OnCompleteQuest();
        }
        else if (QuestCheck.orderQuest == 5 && sceneController.currentScene == "Room")
        {
            OnCompleteQuest();
        }
    }

}