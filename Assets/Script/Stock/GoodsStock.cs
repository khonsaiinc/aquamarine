using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GoodsStock : MonoBehaviour
{
    [Header("InteractIcon")]
    [SerializeField] GameObject interactIcon;
    [Header("StockData")]
    [SerializeField] StockData stockData;

    [Header("Goods")]
    [SerializeField] List<GameObject> goods = new List<GameObject>();
    [Header("Player")]
    [SerializeField] PlayerController playerController;


    bool playerInRange;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange && QuestCheck.outFit == "WorkUniform_HoldingBox")
        {
            if (context.performed)
            {
                Restock();
            }
        }
    }

    void Start()
    {
        //เรียก LoadStock
    }

    void Update()
    {
        #region IconActive
        if (playerInRange && QuestCheck.outFit == "WorkUniform_HoldingBox")
        {
            interactIcon.SetActive(true);
        }
        else
        {
            interactIcon.SetActive(false);
        }
        #endregion
    }

    void Restock()
    {
        if (stockData.goodsInStock <= stockData.maxGoods)
        {
            goods[stockData.goodsInStock].SetActive(true);
            stockData.goodsInStock++;

            playerController.HinaChangeOutfit("WorkUniform");
        }
    }

    void LoadStock()
    {
        for (int i = 0; i < stockData.goodsInStock; i++)
        {
            goods[i].SetActive(true);
        }
    }

    public void ResetStock()
    {
        stockData.goodsInStock = 0;
    }

    #region CheckCollider Player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    #endregion
}
