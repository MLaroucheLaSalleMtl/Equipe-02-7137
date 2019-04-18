using System.Collections;
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
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        PurpleDragon newNpc = new PurpleDragon(instanceId, displayName, level, maxHp, currentHp);
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.PURPLE_DRAGON_TOOTH, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.DRAGON_BONES, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 7, 8));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 7, 8));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 7, 8));
        return newNpc;
    }
    
}
