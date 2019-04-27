using System.Collections;
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
    public GameObject[] itemPrefabs;

    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    /// <summary>
    /// Spawns an item on the ground to pick-up
    /// </summary>
    /// <returns></returns>
    public GameObject SpawnItem (int itemId, Vector3 pos)
    {
        GameObject itemToSpawn = null;
        if (itemPrefabs[itemId] != null)
        {
            itemToSpawn = Instantiate(itemPrefabs[itemId], pos, Quaternion.identity);
        }
        return itemToSpawn;
    }

    void Update ()
    {
        if (inventory == null && Manager.player != null)
        {
            inventory = Manager.player.PlayerInventory;
            inventory.onItemChangedCallBack += UpdateInventoryUI;
        }
    }

}
