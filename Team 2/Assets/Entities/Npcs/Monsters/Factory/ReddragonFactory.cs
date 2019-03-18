using System.Collections;
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
        newNpc.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newNpc;
    }
    
}
