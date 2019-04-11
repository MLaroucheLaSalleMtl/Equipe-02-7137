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

    public override void ExecuteAction(Player player)
    {
        PickUp(player);
    }

    /// <summary>
    /// Add the item to the inventory
    /// </summary>
    public void PickUp(Player player)
    {
        bool wasPicked = player.PlayerInventory.Add(data);
        if (wasPicked) 
            Destroy(gameObject);
    }

}
