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
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        GreenBoar newBoar = new GreenBoar(instanceId, displayName, level, maxHp, currentHp);
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.GREEN_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        return newBoar;
    }
    
}
