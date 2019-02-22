using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 February 2019
/// @description A simple ShellCrab NPC
/// </summary>
public class ShellCrab : NPC
{

    /// <summary>
    /// The animations of the npc
    /// </summary>
    public Animator Animator { get; set; }

    private GameObject shellCrabPrefab;

    #region Constructors

    public ShellCrab (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Shell Crab";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        shellCrabPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.SHELLCRAB];
    }

    public ShellCrab(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        shellCrabPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.SHELLCRAB];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn a this npc
    /// </summary>
    public override void Spawn(Position pos)
    {
        if (!isSpawned)
        {
            WorldPosition = pos;
            WorldModel = Object.Instantiate(shellCrabPrefab);
            WorldModel.name = $"Monster,{InstanceId}";
            Animator = WorldModel.GetComponent<Animator>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// NPC death
    /// </summary>
    public override void Death()
    {
        if (!isDead)
        {
            Debug.Log("Shell Crab is dead.");
            base.Death();
        }
    }

    #endregion

}
