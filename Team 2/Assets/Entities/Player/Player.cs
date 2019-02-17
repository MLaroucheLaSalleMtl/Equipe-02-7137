using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 12 FEB 2019
/// @description The player class, everything related to a player should be here
/// </summary>
public class Player : Entity
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

    /// <summary>
    /// The strength of the player (melee)
    /// </summary>
    public override int Strength { get; set; }

    /// <summary>
    /// The strength of the player (mage)
    /// </summary>
    public int inteligence { get; set; }

    /// <summary>
    /// The strength of the player (archer)
    /// </summary>
    public int dexterity { get; set; }

    /// <summary>
    /// The defence of the player
    /// </summary>
    public override int Defence { get; set; }

    /// <summary>
    /// The class of the player
    /// </summary>
    public PlayerClass Class { get; set; }

    /// <summary>
    /// The unity game object associated to the player to interact with the transform, position, etc.
    /// </summary>
    public override GameObject WorldModel { get; set; }

    #region getTotalStats

    public int GetTotalMaxHp()
    {
        float mod=0;
        foreach(Skill s in Class.Skills)
        {
            mod += s.HealtModifyer;
        }
        return (int)(maxHp* mod);
    }

    public int GetTotalDexterity()
    {
        float mod = 0;
        foreach (Skill s in Class.Skills)
        {
            mod += s.DexterityModifyer;
        }
        return (int)(dexterity * mod);
    }

    public int GetTotalInteligence()
    {
        float mod = 0;
        foreach (Skill s in Class.Skills)
        {
            mod += s.InteligenceModifyer;
        }
        return (int)(inteligence * mod);
    }

    public int GetTotalStrength()
    {
        float mod = 0;
        foreach (Skill s in Class.Skills)
        {
            mod += s.StrenghtModifyer;
        }
        return (int)(Strength * mod);
    }

    #endregion
    #endregion

    #region Player interaction

    /// <summary>
    /// The NPC attacks another entity (could be a player, another npc, etc.)
    /// </summary>
    /// <param name="toAttack">The entity to attack</param>
    public override void Attack(Entity toAttack)
    {
        toAttack.RemoveHp(Strength);
    }

    /// <summary>
    /// Gives hp to the npc (healing, etc.)
    /// </summary>
    /// <param name="amount">amount of hp to give</param>
    public override void GiveHp(int amount)
    {
        int amountToGive = Mathf.Abs(amount);
        currentHp += amountToGive;
    }

    /// <summary>
    /// Remove 1 level from the NPC
    /// </summary>
    public override void LevelDown()
    {
        level--;
    }

    /// <summary>
    /// Give 1 level to the NPC
    /// </summary>
    public override void LevelUp()
    {
        level++;
    }

    /// <summary>
    /// Moves the NPC
    /// </summary>
    /// <param name="newPosition">The position to move the npc to</param>
    public override void Move(Transform transform, Position newPosition)
    {
        Vector3.Lerp(transform.position, new Vector3(newPosition.X, newPosition.Y, newPosition.Z), 0.5f);
    }

    /// <summary>
    /// Player is dead
    /// </summary>
    public virtual void Death()
    {
        Debug.Log("I am dead");
    }

    /// <summary>
    /// Remove hp from the npc
    /// </summary>
    /// <param name="amount">amount of hp to remove</param>
    public override void RemoveHp(int amount)
    {
        int amountToRemove = Mathf.Abs(amount);
        currentHp -= amountToRemove;
    }

    /// <summary>
    /// Set the level of a npc
    /// </summary>
    /// <param name="level">the level to set</param>
    public override void SetLevel(int level)
    {
        this.level = level;
    }

    #endregion

    #region Display / UI

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

}
