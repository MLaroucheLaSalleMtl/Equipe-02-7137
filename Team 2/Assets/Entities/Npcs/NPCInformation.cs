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
        SKELETON,
        BLUE_BOAR,
        GREEN_BOAR,
        GOLD_BOAR,
        BLUE_DRAGON,
        GREEN_DRAGON,
        PURPLE_DRAGON,
        RED_DRAGON,
    }

    public enum NPCPrefabId
    {
        RED_BOAR,
        IMPLING,
        SKELETON,
        BLUE_BOAR,
        GREEN_BOAR,
        GOLD_BOAR,
        BLUE_DRAGON,
        GREEN_DRAGON,
        PURPLE_DRAGON,
        RED_DRAGON,
    }

    //Animator state info
    public enum NPCStateInfo {
        ATTACK,
        BLOCK,
        DEATH,
    }

    public const int HPRate = 10;
}
