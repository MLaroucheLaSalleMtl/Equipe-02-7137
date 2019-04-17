using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 13 FEB 19
/// @description All the information needed related to items
/// </summary>
public static class ItemInformation
{
    /// <summary>
    /// Rarity of an item
    /// </summary>
    public enum ItemRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        MYTHIC,
        LEGENDARY
    }

    /// <summary>
    /// Which range of percentage each rarity is classified
    /// Example: An item that the drop percentage is 54% is classified as common, because common is 10% and up
    /// Example2: An item that the drop percentage is 2% is classified as mythic, because mythic is from 1% to 3%
    /// </summary>
    public enum RarityChances
    {
        COMMON = 75,
        UNCOMMON = 14,
        RARE = 6,
        MYTHIC = 3,
        LEGENDARY = 1
    }

    /// <summary>
    /// Item ids of the type of currencies
    /// </summary>
    public enum MoneyIds
    {
        CASH = 1,
    }

    /// <summary>
    /// Item ids
    /// </summary>
    public enum ItemIds
    {
        BARBARIAN_AXE,
        CASH,
        BONES,
        GREEN_HIDE,
        BLUE_HIDE,
        RED_HIDE,
        GOLD_HIDE,
    }
}
