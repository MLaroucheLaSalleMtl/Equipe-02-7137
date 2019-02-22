using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 11 February 2019
/// @description A simple goblin NPC
/// </summary>
public class Goblin : NPC
{

    /// <summary>
    /// The animations of the npc
    /// </summary>
    public Animation Animations { get; set; }

    private GameObject goblinPrefab;

    #region Constructors

    public Goblin (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Goblin";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        goblinPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.GOBLIN];
    }

    public Goblin (int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        goblinPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.GOBLIN];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn a goblin
    /// </summary>
    public override void Spawn(Position pos)
    {
        if (!isSpawned)
        {
            WorldPosition = pos;
            WorldModel = Object.Instantiate(goblinPrefab);
            WorldModel.name = $"Monster,{InstanceId}";
            Animations = WorldModel.GetComponent<Animation>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Goblin death
    /// </summary>
    public override void Death()
    {
        if (!isDead)
        {
            Animations.Play("death");
            Debug.Log("Goblin is dead.");
            base.Death();
        }
    }

    #endregion

}
