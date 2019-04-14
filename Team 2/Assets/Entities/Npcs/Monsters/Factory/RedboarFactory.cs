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
        return newBoar;
    }
    
}
