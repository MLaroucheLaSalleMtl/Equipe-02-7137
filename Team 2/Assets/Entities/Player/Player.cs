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
    /// The current position of the player
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
    /// The current level of the player
    /// </summary>
    public override int Level
    {
        get
        {
            return level;
        }
    }

    private int experience;
    /// <summary>
    /// The current experience of the player
    /// </summary>
    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
            CheckForLevelUp();
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
            float mod = 1;
            foreach (Skill s in Class.UnlockedSkills)
            {
                mod += s.HealtModifyer;
            }
            return (int)(maxHp * mod);
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
    private int strength;
    public override int Strength {
        get
        {
            float mod = 0;
            foreach (Skill s in Class.UnlockedSkills)
            {
                mod += s.StrenghtModifyer;
            }
            return (int)(strength * mod);
        }
        set
        {
            strength = value;
        }
    }

    /// <summary>
    /// The strength of the player (mage)
    /// </summary>
    private int inteligence;
    public int Inteligence
    {
        get
        {
            float mod = 0;
            foreach (Skill s in Class.UnlockedSkills)
            {
                mod += s.InteligenceModifyer;
            }
            return (int)(inteligence * mod);
        }
        set
        {
            inteligence = value;
        }
    }

    /// <summary>
    /// The strength of the player (archer)
    /// </summary>
    private int dexterity;
    public int Dexterity
    {
        get
        {
            float mod = 0;
            foreach (Skill s in Class.UnlockedSkills)
            {
                mod += s.DexterityModifyer;
            }
            return (int)(dexterity * mod);
        }
        set
        {
            dexterity = value;
        }
    }

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

    /// <summary>
    /// The cash of the player
    /// </summary>
    public int Money { get; set; }

    /// <summary>
    /// If the player is currently attacking or not
    /// </summary>
    public bool IsAttacking { get; set; }
   
    /// <summary>
    /// animator of the player
    /// </summary>
    public Animator PlayerController { get; set; }

    /// <summary>
    /// is the player dead or not
    /// </summary>
    public bool IsDead { get; set; }

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
    /// Checks if the player needs to level up, if yes, level up
    /// </summary>
    public void CheckForLevelUp()
    {
        if (Experience >= GetXpToLevelUp(Level))
        {
            LevelUp();
        }
    }

    /// <summary>
    /// Moves the NPC
    /// </summary>
    /// <param name="newPosition">The position to move the npc to</param>
    public override void Move(Position newPosition)
    {
        Vector3.Lerp(WorldModel.transform.position, new Vector3(newPosition.X, newPosition.Y, newPosition.Z), 0.5f);
    }

    /// <summary>
    /// Player is dead
    /// </summary>
    public virtual void Death()
    {
        PlayerController.SetTrigger("Death");
        IsDead = true;
    }

    /// <summary>
    /// Remove hp from the npc
    /// </summary>
    /// <param name="amount">amount of hp to remove</param>
    public override void RemoveHp(int amount)
    {
        int amountToRemove = Mathf.Abs(amount);
        if (currentHp <= amountToRemove)
        {
            currentHp = 0;
            Death();
        }
        else
        {
            currentHp -= amountToRemove;
        }
    }

    /// <summary>
    /// Set the level of a npc
    /// </summary>
    /// <param name="level">the level to set</param>
    public override void SetLevel(int level)
    {
        this.level = level;
    }

    /// <summary>
    /// Creates a new player
    /// </summary>
    /// <param name="displayName"></param>
    /// <param name="strength"></param>
    /// <param name="inteligence"></param>
    /// <param name="dexterity"></param>
    /// <param name="defence"></param>
    /// <param name="money"></param>
    /// <param name="playerclass"></param>
    /// <param name="worldModel"></param>
    public Player(string displayName = "Default Name", int level = 1, int maxhp = 10, int strength = 1, int inteligence = 0, int dexterity = 0, int defence = 0, int money = 100, PlayerClass playerclass = null, GameObject worldModel = null)
    {
        this.strength = strength;
        this.inteligence = inteligence;
        this.dexterity = dexterity;
        Defence = defence;
        Class = playerclass;
        WorldModel = worldModel;
        Money = money;
        this.displayName = displayName;
        maxHp = maxhp;
        GiveHp(MaxHP);
        SetLevel(level);
        Experience = GetXpToLevelUp(level - 1);
        IsAttacking = false;
        PlayerController = WorldModel.GetComponent<Animator>();
        IsDead = false;
    }

    #endregion

    /// <summary>
    /// Get the amount of xp necessary to level up
    /// </summary>
    /// <returns></returns>
    public int GetXpToLevelUp(int level)
    {
        if (level == 0)
            return 0;
        return ((int)(Mathf.Ceil(level * 5 / 3)) + 83) + GetXpToLevelUp(level - 1);
    }

}
