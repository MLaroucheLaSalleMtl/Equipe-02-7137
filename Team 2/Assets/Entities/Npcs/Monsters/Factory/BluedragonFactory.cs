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
        return newNpc;
    }
    
}
