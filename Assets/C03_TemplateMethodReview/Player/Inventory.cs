using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TemplateMethod
{
    public class Inventory : MonoBehaviour
    {
        public int CoinCount { get; private set; } = 0;

        public void AddCoin(int numberOfCoins)
        {
            CoinCount += numberOfCoins;
            Debug.Log("Collect! Coins: " + CoinCount);
        }
    }
}

