using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The creator of implings
/// </summary>
public class ImplingFactory : MonsterFactory
{

    /// <summary>
    /// Creates an Impling
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        Impling newNPC = new Impling(instanceId, displayName, level, maxHp, currentHp);
        return newNPC;
    }
    
}
