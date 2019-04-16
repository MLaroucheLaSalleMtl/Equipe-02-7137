using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of gold boars
/// </summary>
public class GoldboarFactory : MonsterFactory
{

    /// <summary>
    /// Creates a gold boar
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        GoldBoar newBoar = new GoldBoar(instanceId, displayName, level, maxHp, currentHp);
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.GOLD_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 4, 5));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 4, 5));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 4, 5));
        return newBoar;
    }
    
}
