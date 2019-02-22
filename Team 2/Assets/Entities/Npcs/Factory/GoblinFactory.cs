using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 FEB 19
/// @description The creator of goblins
/// </summary>
public class GoblinFactory : MonsterFactory
{

    /// <summary>
    /// Creates a goblin
    /// </summary>
    /// <returns></returns>
    public override NPC CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        Goblin newGoblin = new Goblin(instanceId, displayName, level, maxHp, currentHp);
        newGoblin.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newGoblin;
    }
    
}
