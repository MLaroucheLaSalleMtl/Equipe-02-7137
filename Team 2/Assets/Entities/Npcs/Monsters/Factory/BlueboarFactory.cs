using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of blue boars
/// </summary>
public class BlueboarFactory : MonsterFactory
{

    /// <summary>
    /// Creates a blue boar
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        BlueBoar newBoar = new BlueBoar(instanceId, displayName, level, maxHp, currentHp);
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.BLUE_HIDE, ItemInformation.RarityChances.COMMON, false, 1, 1));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        newBoar.DropTable.Add(new ItemDrop((int)ItemInformation.ItemIds.CASH, ItemInformation.RarityChances.COMMON, true, 2, 3));
        return newBoar;
    }
    
}
