using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 1 February 2019
/// @description The abstract design of a non playable character.
/// </summary>
public class NPC : Entity
{

    #region Fields
    /// <summary>
    /// The current position of the npc
    /// </summary>
    public override Position WorldPosition
    {
        get
        {
            return worldPos;
        }
        set
        {
            worldPos = value;
        }
    }

    /// <summary>
    /// The current level of the npc
    /// </summary>
    public override int Level
    {
        get
        {
            return level;
        }
    }

    /// <summary>
    /// The name of the NPC
    /// </summary>
    public override string DisplayName
    {
        get
        {
            return displayName;
        }
    }

    /// <summary>
    /// The max HP of the npc
    /// </summary>
    public override int MaxHP
    {
        get
        {
            return maxHp;
        }
    }

    /// <summary>
    /// The current hp of a npc
    /// </summary>
    public override int CurrentHp
    {
        get
        {
            return currentHp;
        }
    }

    #endregion

    #region NPC interaction

    /// <summary>
    /// The NPC attacks another entity (could be a player, another npc, etc.)
    /// </summary>
    /// <param name="toAttack">The entity to attack</param>
    public override void Attack(Entity toAttack)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Gives hp to the npc (healing, etc.)
    /// </summary>
    /// <param name="amount">amount of hp to give</param>
    public override void GiveHp(int amount)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Remove 1 level from the NPC
    /// </summary>
    public override void LevelDown()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Give 1 level to the NPC
    /// </summary>
    public override void LevelUp()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Moves the NPC
    /// </summary>
    /// <param name="newPosition">The position to move the npc to</param>
    public override void Move(Position newPosition)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Remove hp from the npc
    /// </summary>
    /// <param name="amount">amount of hp to remove</param>
    public override void RemoveHp(int amount)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Set the level of a npc
    /// </summary>
    /// <param name="level">the level to set</param>
    public override void SetLevel(int level)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Spawn the npc, but since this is an abstract design, we can't spawn it
    /// </summary>
    public virtual void Spawn(Position pos)
    {
        Debug.Log("You cannot spawn the abstract NPC.");
    }

    #endregion
   
    #region NPC display / UI
    /// <summary>
    /// Called when the NPC is created
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Called once per game tick after the NPC is spawned
    /// </summary>
    void Update()
    {
        
    }

    #endregion

}
