using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @descripton Information about the monsters (rates, etc.)
/// @date 11 FEB 2019
/// @author Samuel Paquette
/// </summary>
public static class MonsterInformation
{
    public enum MonsterNames
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

    public enum MonstersPrefabId
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
    public enum MonstersStateInfo {
        ATTACK,
        BLOCK,
        DEATH,
    }

    public const int HPRate = 10;
}
