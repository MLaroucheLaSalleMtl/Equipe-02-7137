﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A purple dragon npc
/// </summary>
public class PurpleDragon : NPC
{

    /// <summary>
    /// The animator of the npc
    /// </summary>
    public Animator Animator { get; set; }

    private GameObject npcPrefab;

    #region Constructors

    public PurpleDragon(int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Blue Dragon";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.PURPLE_DRAGON];
    }

    public PurpleDragon(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.PURPLE_DRAGON];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn
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
    /// Block
    /// </summary>
    public override void Block ()
    {
        isBlocking = true;
        Animator.SetTrigger("Block");
    }

    /// <summary>
    /// Death
    /// </summary>
    public override void Death()
    {
        if (!isDead)
        {
            Animator.SetTrigger("Death");
            Debug.Log("Purple Dragon is dead.");
            base.Death();
        }
    }

    #endregion

}
