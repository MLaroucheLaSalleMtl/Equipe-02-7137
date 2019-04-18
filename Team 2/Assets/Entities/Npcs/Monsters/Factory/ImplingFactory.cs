using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The creator of implings
/// </summary>
public class ImplingFactory : MonsterFactory
{

    /// <summary>
    /// Creates an Impling
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        Impling newNPC = new Impling(instanceId, displayName, level, maxHp, currentHp);
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.GREEN_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.BLUE_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.GOLD_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNPC.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.RED_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        return newNPC;
    }
    
}
