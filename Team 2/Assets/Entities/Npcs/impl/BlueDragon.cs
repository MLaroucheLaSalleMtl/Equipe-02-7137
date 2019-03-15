using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A blue dragon npc
/// </summary>
public class BlueDragon : NPC
{

    /// <summary>
    /// The animator of the npc
    /// </summary>
    public Animator Animator { get; set; }

    private GameObject npcPrefab;

    #region Constructors

    public BlueDragon(int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Blue Dragon";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.BLUE_DRAGON];
    }

    public BlueDragon(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.BLUE_DRAGON];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn a red boar
    /// </summary>
    public override void Spawn(Position pos)
    {
        if (!isSpawned)
        {
            WorldPosition = pos;
            WorldModel = Object.Instantiate(npcPrefab);
            WorldModel.name = $"Monster,{InstanceId}";
            Animator = WorldModel.GetComponent<Animator>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Block for red boar
    /// </summary>
    public override void Block ()
    {
        Animator.SetTrigger("Block");
    }

    /// <summary>
    /// Goblin death
    /// </summary>
    public override void Death()
    {
        if (!isDead)
        {
            Animator.SetTrigger("Death");
            Debug.Log("Blue Dragon is dead.");
            base.Death();
        }
    }

    #endregion

}
