using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 11 avr 19
/// @description Inventory of the player
/// </summary>
public class Inventory
{
    public List<ItemData> items = new List<ItemData>();

    public const int Spaces = 16;

    GameManager manager;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    
    /// <summary>
    /// Add an item to the inventory
    /// </summary>
    /// <param name="item"></param>
    public bool Add (ItemData item)
    {
        if (items.Count < Spaces)
        {
            items.Add(item);
            if (onItemChangedCallBack != null) 
                onItemChangedCallBack.Invoke();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Remove an item from the inventory
    /// </summary>
    /// <param name="item"></param>
    public bool Remove (ItemData item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
            return true;
        }
        return false;
    }

}
