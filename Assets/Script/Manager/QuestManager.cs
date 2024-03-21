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

    [Header("StockData")]
    [SerializeField] List<StockData> allGoodsInStocks = new List<StockData>();
    public int maxGoodsInStock;
    public int currentGoodsInStock;

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

        MaxGoodsInStock();
    }

    void Update()
    {
        ShowQuestText();
        TotalGoodsInStock();
        WorkingComplete();
    }

    #region StockData

    void MaxGoodsInStock()
    {
        for (int i = 0; i < allGoodsInStocks.Count; i++)
        {
            maxGoodsInStock += allGoodsInStocks[i].maxGoods;
        }
    }
    void TotalGoodsInStock()
    {
        currentGoodsInStock = allGoodsInStocks[0].goodsInStock + allGoodsInStocks[1].goodsInStock;
    }

    public void ResetStock()
    {
        for (int i = 0; i < allGoodsInStocks.Count; i++)
        {
            allGoodsInStocks[i].goodsInStock = 0;
        }
        QuestCheck.isWorking = true;
    }

    void WorkingComplete()
    {
        if (currentGoodsInStock >= maxGoodsInStock && QuestCheck.isWorking)
        {
            QuestCheck.isWorking = false;
            OnCompleteQuest();
        }
    }
    #endregion
    public void ShowQuestText()
    {
        mainText = dataQuests[orderQuest].titleQuest;//เปลี่ยนหัวข้อเควส
        descriptText = dataQuests[orderQuest].informationQuest;//เปลี่ยนคำอธิบายเควส

        if (QuestCheck.isWorking && QuestCheck.orderQuest == 3)
        {
            questText.text = mainText + " : " + descriptText + "(" + currentGoodsInStock + "/" + maxGoodsInStock + ")";

        }
        else
        {
            questText.text = mainText + " : " + descriptText;
        }

    }

    public void OnCompleteQuest()
    {
        orderQuest++;
        QuestCheck.orderQuest = orderQuest; //บันทึกลำดับเควสให้ตัวกลาง
    }

    public void OnStartSceneQuestComplete()//เมื่อเริ่มซีนให้เควสเสร็จ เช่น ไปสถานที่ต่างๆ
    {
        if (QuestCheck.orderQuest == 2 && sceneController.currentScene == "SuperMarket" || QuestCheck.orderQuest == 11 && sceneController.currentScene == "SuperMarket")
        {
            OnCompleteQuest();
        }
        else if (QuestCheck.orderQuest == 6 && sceneController.currentScene == "Room")
        {
            OnCompleteQuest();
        }
    }

}