﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 13 February 2019
/// @description Handles everything related to the items
/// </summary>
public class ItemHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }
    Inventory inventory { get; set; }
    public Transform inventoryParentObject;
    InventorySlot[] inventorySlots;

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inventory = Manager.player.PlayerInventory;
        inventory.onItemChangedCallBack += UpdateInventoryUI;
        inventorySlots = inventoryParentObject.GetComponentsInChildren<InventorySlot>();
    }

    /// <summary>
    /// Updates the inventory UI
    /// </summary>
    void UpdateInventoryUI ()
    {
        for (int index = 0; index < inventorySlots.Length; index++)
        {
            if (index < inventory.items.Count)
            {
                inventorySlots[index].AddItem(inventory.items[index]);
            }
            else
            {
                inventorySlots[index].ClearSlot();
            }
        }
    }

}
