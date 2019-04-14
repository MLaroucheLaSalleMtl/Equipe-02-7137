using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 13 FEB 19
/// @description An item in the game
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{

    public int itemId = -1;
    new public string name = "New Item";
    public Sprite icon = null;
    public string description = "Empty description";
    public int value = 0;
    public ItemInformation.ItemRarity rarity = ItemInformation.ItemRarity.COMMON;

    public ItemData (int itemId, string name, Sprite icon, string desc, int value, ItemInformation.ItemRarity rarity)
    {
        this.itemId = itemId;
        this.name = name;
        this.icon = icon;
        this.description = desc;
        this.value = value;
        this.rarity = rarity;
    }

    public virtual void Use ()
    {
        //Use the item and execute an action, equip, etc.
        Debug.Log($"Using {name}");
    }

}
