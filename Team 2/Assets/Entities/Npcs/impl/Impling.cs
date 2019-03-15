using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 February 2019
/// @description A simple Impling NPC
/// </summary>
public class Impling : NPC
{

    /// <summary>
    /// The animations of the npc
    /// </summary>
    public Animator Animator { get; set; }

    private GameObject implingPrefab;

    #region Constructors

    public Impling (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Impling";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        implingPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.IMPLING];
    }

    public Impling (int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        implingPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.IMPLING];
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
            WorldModel = Object.Instantiate(implingPrefab);
            WorldModel.name = $"Monster,{InstanceId}";
            Animator = WorldModel.GetComponent<Animator>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Block animation of an impling
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
            Debug.Log("Impling is dead.");
            base.Death();
        }
    }

    #endregion

}
