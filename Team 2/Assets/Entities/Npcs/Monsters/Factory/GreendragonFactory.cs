using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 MARS 19
/// @description The creator of green dragons
/// </summary>
public class GreendragonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a green dragon
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        GreenDragon newNpc = new GreenDragon(instanceId, displayName, level, maxHp, currentHp);
        return newNpc;
    }
    
}
