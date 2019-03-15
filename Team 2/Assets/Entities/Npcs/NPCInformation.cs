using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @descripton Information about the npcs (rates, etc.)
/// @date 11 FEB 2019
/// @author Samuel Paquette
/// </summary>
public static class NPCInformation
{
    public enum NPCNames
    {
        RED_BOAR,
        IMPLING,
        SHELLCRAB,
        BLUE_BOAR,
        GREEN_BOAR,
        GOLD_BOAR,
    }

    public enum NPCPrefabId
    {
        RED_BOAR,
        IMPLING,
        SHELLCRAB,
        BLUE_BOAR,
        GREEN_BOAR,
        GOLD_BOAR,
    }

    public const int HPRate = 10;
}
