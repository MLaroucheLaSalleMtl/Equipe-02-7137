using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 AVR 19
/// @description A cash item in the game
/// </summary>
[CreateAssetMenu(fileName = "New Money", menuName = "Inventory/Money")]
public class CashData : ItemData
{
    public int amount = 1;

    public CashData (int itemId, string name, Sprite icon, string desc, int value, ItemInformation.ItemRarity rarity) : base(itemId, name, icon, desc, value, rarity)
    {
        this.itemId = itemId;
        this.name = name;
        this.icon = icon;
        this.description = desc;
        this.value = value;
        this.rarity = rarity;
    }

    public override void Use ()
    {
        //Use the item and execute an action, equip, etc.
        Debug.Log($"I got {amount} coins.");
    }

}
