using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 14 AVR 2019
/// @description Handles everything related to an inventory slot in the UI
/// </summary>
public class InventorySlot : MonoBehaviour
{

    ItemData item;
    public Image icon;
    public Button removeButton;
    GameManager manager;
    Inventory inventory;

    void Start ()
    {
        manager = FindObjectOfType<GameManager>();
        inventory = manager.player.PlayerInventory;
    }

    public void AddItem (ItemData item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton ()
    {
        DropItem();
        inventory.Remove(item);
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    /// <summary>
    /// Drops an item on the floor
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="pos"></param>
    public void DropItem()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomZ = Random.Range(-5f, 5f);
        Vector3 playerPos = manager.player.WorldModel.transform.position;
        Vector3 dropPos = new Vector3(playerPos.x + randomX, playerPos.y, playerPos.z + randomZ);

        manager.itemHandler.SpawnItem(item.itemId, dropPos);
    }
}
