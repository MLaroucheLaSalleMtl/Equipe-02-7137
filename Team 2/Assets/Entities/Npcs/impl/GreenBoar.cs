using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A simple green boar NPC
/// </summary>
public class GreenBoar : NPC
{

    /// <summary>
    /// The animator of the npc
    /// </summary>
    public Animator Animator { get; set; }

    private GameObject greenboarPrefab;

    #region Constructors

    public GreenBoar(int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Green Boar";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        greenboarPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.GREEN_BOAR];
    }

    public GreenBoar(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        greenboarPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.GREEN_BOAR];
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
            WorldModel = Object.Instantiate(greenboarPrefab);
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
            Debug.Log("Green boar is dead.");
            base.Death();
        }
    }

    #endregion

}
