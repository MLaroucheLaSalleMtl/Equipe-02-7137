﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of red dragons
/// </summary>
public class ReddragonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a red dragon
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        RedDragon newNpc = new RedDragon(instanceId, displayName, level, maxHp, currentHp);
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.RED_DRAGON_TOOTH, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.DRAGON_BONES, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 8, 9));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 8, 9));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 8, 9));
        return newNpc;
    }
    
}
