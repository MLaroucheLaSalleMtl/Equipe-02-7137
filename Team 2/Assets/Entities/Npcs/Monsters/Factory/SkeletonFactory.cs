using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The creator ofskeletons
/// </summary>
public class SkeletonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a Skeleton
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        Skeleton newNPC = new Skeleton(instanceId, displayName, level, maxHp, currentHp);

        //Drops
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.BONES, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 1, 2));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 1, 2));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 1, 2));

        return newNPC;
    }
    
}
