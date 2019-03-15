﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of purple dragons
/// </summary>
public class PurpledragonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a purple dragon
    /// </summary>
    /// <returns></returns>
    public override NPC CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        PurpleDragon newNpc = new PurpleDragon(instanceId, displayName, level, maxHp, currentHp);
        newNpc.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newNpc;
    }
    
}
