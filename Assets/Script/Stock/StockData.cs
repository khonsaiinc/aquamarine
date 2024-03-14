using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StockData", menuName = "ScriptableObjects/StockData", order = 1)]
public class StockData : ScriptableObject
{
    public int maxGoods = 12;
    public int goodsInStock;
}

