using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 FEB 19
/// @description The creator of goblins
/// </summary>
public class GoblinFactory : MonsterFactory
{
    /// <summary>
    /// Fields
    /// </summary>
    private readonly int instanceId;
    private readonly string displayName;
    private readonly int level;
    private readonly int maxHp;
    private readonly int currentHp;

    /// <summary>
    /// Constructor for the creator
    /// </summary>
    /// <param name="instanceId"></param>
    /// <param name="displayName"></param>
    /// <param name="level"></param>
    /// <param name="maxHp"></param>
    /// <param name="currentHp"></param>
    public GoblinFactory (int instanceId, string displayName, int level, int maxHp, int currentHp)
    {
        this.instanceId = instanceId;
        this.displayName = displayName;
        this.level = level;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
    }

    /// <summary>
    /// Creates a goblin
    /// </summary>
    /// <returns></returns>
    public override NPC GetNPC()
    {
        return new Goblin(instanceId, displayName, level, maxHp, currentHp);
    }

}
