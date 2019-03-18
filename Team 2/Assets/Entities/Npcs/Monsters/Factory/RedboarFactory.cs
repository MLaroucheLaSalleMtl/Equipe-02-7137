using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 FEB 19
/// @description The creator of red boars
/// </summary>
public class RedboarFactory : MonsterFactory
{

    /// <summary>
    /// Creates a goblin
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        RedBoar newBoar = new RedBoar(instanceId, displayName, level, maxHp, currentHp);
        newBoar.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newBoar;
    }
    
}
