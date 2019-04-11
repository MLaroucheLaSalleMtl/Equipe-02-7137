using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The creator ofskeletons
/// </summary>
public class SkeletonFactory : MonsterFactory
{

    /// <summary>
    /// Creates a Skeleton
    /// </summary>
    /// <returns></returns>
    public override Monster CreateNewNpc(int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        Skeleton newNPC = new Skeleton(instanceId, displayName, level, maxHp, currentHp);
        return newNPC;
    }
    
}
