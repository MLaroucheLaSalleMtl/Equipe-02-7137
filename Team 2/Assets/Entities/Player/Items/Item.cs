using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 11 avr 2019
/// @description The game object of the item in the game
/// </summary>
public class Item : Interactable
{

    public ItemData data;
    public bool isMoney = false;

    public override void ExecuteAction(Player player)
    {
        PickUp(player);
    }

    /// <summary>
    /// Add the item to the inventory
    /// </summary>
    public void PickUp(Player player)
    {
        bool wasPicked = false;
        if (!isMoney)
        {
            wasPicked = player.PlayerInventory.Add(data);
        }
        else
        {
            switch (data.itemId)
            {
                case (int)ItemInformation.MoneyIds.CASH:
                    player.Money += ((CashData)data).amount;
                    FindObjectOfType<GameManager>().playerHandler.UpdatePlayerBarUI();
                    break;
            }
        }
            
        //if the item was 
        if (wasPicked || isMoney) 
            Destroy(gameObject);
    }

}
