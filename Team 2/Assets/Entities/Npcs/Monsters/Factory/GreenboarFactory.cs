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
        return newBoar;
    }
    
}
