using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 1 February 2019
/// @description The abstract design of a non playable character.
/// </summary>
public class NPC : Entity
{

    #region Fields

    /// <summary>
    /// The spawn Id of the npc (currently spawned)
    /// </summary>
    public int InstanceId { get; set; }

    /// <summary>
    /// If the npc is dead or not
    /// </summary>
    public bool isDead { get; set; }

    /// <summary>
    /// If the npc has been spawned
    /// </summary>
    public bool isSpawned = false;

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
    /// The defence of the npc
    /// </summary>
    public override int Defence { get; set; }

    /// <summary>
    /// The attack of the npc
    /// </summary>
    public override int Strength { get; set; }

    /// <summary>
    /// The game object in unity to interact with transform, position, etc.
    /// </summary>
    public override GameObject WorldModel { get; set; }

    /// <summary>
    /// The overlay of the npc
    /// </summary>
    public Text Overlay { get; set; }

    /// <summary>
    /// The drop table of loots of the npc, if empty, npc drops nothing
    /// </summary>
    public List<ItemDrop> DropTable { get; set; } = new List<ItemDrop>();

    #endregion

    #region NPC interaction

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
        UpdateOverlay();
    }

    /// <summary>
    /// Give 1 level to the NPC
    /// </summary>
    public override void LevelUp()
    {
        level++;
        UpdateOverlay();
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
    /// Remove hp from the npc
    /// </summary>
    /// <param name="amount">amount of hp to remove</param>
    public override void RemoveHp(int amount)
    {
        currentHp -= Mathf.Abs(amount);
    }

    /// <summary>
    /// Set the level of a npc
    /// </summary>
    /// <param name="level">the level to set</param>
    public override void SetLevel(int level)
    {
        this.level = level;
        UpdateOverlay();
    }

    /// <summary>
    /// Spawn the npc, but since this is an abstract design, we can't spawn it
    /// </summary>
    public virtual void Spawn(Position pos)
    {
        Overlay = GameObject.Find($"Monster,{InstanceId}").transform.Find("Canvas/MonsterOverlay").GetComponent<Text>();
        Overlay.text = $"{DisplayName} - Level {Level}";
        isDead = false;
        isSpawned = true;
    }

    /// <summary>
    /// Deletes the NPC, he is dead
    /// </summary>
    public virtual void Death ()
    {
        if (!isDead)
        {
            if (DropTable.Count > 0)
            {
                Debug.Log($"I dropped {DropTable[0].Loot.ItemName}");
            }
        }
        isDead = true;
    }

    #endregion
   
    #region NPC display / UI

    /// <summary>
    /// Update the overlay of the npc
    /// </summary>
    void UpdateOverlay()
    {
        Overlay.text = $"{DisplayName} - Level {Level}";
    }

    #endregion

}
