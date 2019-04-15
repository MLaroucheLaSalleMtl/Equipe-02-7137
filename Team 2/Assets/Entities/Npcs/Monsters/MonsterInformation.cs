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
    public enum Monsters
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

    public enum MonsterPrefabIds
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

    public static Dictionary<Monsters, float>monsterDificulties=new Dictionary<Monsters, float> {
        { Monsters.RED_BOAR, 0.5f },
        { Monsters.IMPLING, 1 },
        { Monsters.SKELETON, 1 },
        { Monsters.BLUE_BOAR, 1 },
        { Monsters.GREEN_BOAR, 1 },
        { Monsters.GOLD_BOAR, 1.5f },
        { Monsters.BLUE_DRAGON, 2 },
        { Monsters.GREEN_DRAGON, 2 },
        { Monsters.PURPLE_DRAGON, 4 },
        { Monsters.RED_DRAGON, 3 },



    };
        

    public const int HPRate = 10;
}
