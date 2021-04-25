using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilize Template Method to hook into OnPickup - easy extension and variability!
/// </summary>
namespace TemplateMethod
{
    public class CoinPickup : Pickup
    {
        [SerializeField] int _coinValue = 1;

        protected override void OnPickup(Player player)
        {
            Inventory inventory = 
                player.gameObject.GetComponent<Inventory>();
            if(inventory != null)
            {
                inventory.AddCoin(_coinValue);
            }
        }
    }
}

