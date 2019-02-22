using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The creator of shell crabs
/// </summary>
public class ShellCrabFactory : MonsterFactory
{

    /// <summary>
    /// Creates a Shell crab
    /// </summary>
    /// <returns></returns>
    public override NPC CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        ShellCrab newNPC = new ShellCrab(instanceId, displayName, level, maxHp, currentHp);
        newNPC.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newNPC;
    }
    
}
