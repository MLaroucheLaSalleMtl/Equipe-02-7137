using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemInformation;

/// <summary>
/// @author Samuel Paquette
/// @date 13 FEB 19
/// @description An item in the game
/// </summary>
public class Item
{

    public int ItemId { get; set; }
    public int InstanceId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public GameObject ItemPrefab { get; set; }
    public GameObject WorldModel { get; set; }
    public ItemRarity Rarity { get; set; }

    public Item (int itemId, int instanceId, string itemName, string itemDescription, int value, GameObject prefab, GameObject model, ItemRarity rarity)
    {
        ItemId = itemId;
        InstanceId = instanceId;
        ItemName = itemName;
        Description = itemDescription;
        Value = value;
        ItemPrefab = prefab;
        WorldModel = model;
        Rarity = rarity;
    }

}
