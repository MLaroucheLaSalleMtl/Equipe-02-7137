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
        return newBoar;
    }
    
}
