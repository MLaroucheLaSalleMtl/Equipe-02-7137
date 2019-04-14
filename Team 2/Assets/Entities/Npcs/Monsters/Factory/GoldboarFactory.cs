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
        return newBoar;
    }
    
}
