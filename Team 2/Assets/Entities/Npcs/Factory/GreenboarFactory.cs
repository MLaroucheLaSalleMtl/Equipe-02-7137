using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of green boars
/// </summary>
public class GreenboarFactory : MonsterFactory
{

    /// <summary>
    /// Creates a green boar
    /// </summary>
    /// <returns></returns>
    public override NPC CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        GreenBoar newBoar = new GreenBoar(instanceId, displayName, level, maxHp, currentHp);
        newBoar.DropTable.Add(new ItemDrop(new Item(0, 0, "Sword", "Nice sword", 5, null, null, ItemInformation.ItemRarity.LEGENDARY)
                                    , ItemInformation.RarityChances.LEGENDARY, 1, 1));
        return newBoar;
    }
    
}
