using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of blue dragons
/// </summary>
public class BluedragonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a blue dragon
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        BlueDragon newNpc = new BlueDragon(instanceId, displayName, level, maxHp, currentHp);
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.BLUE_DRAGON_TOOTH, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.DRAGON_BONES, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 5, 6));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 5, 6));
        newNpc.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 5, 6));
        return newNpc;
    }
    
}
