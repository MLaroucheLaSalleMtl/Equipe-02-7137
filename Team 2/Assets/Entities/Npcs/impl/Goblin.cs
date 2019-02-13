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

    private GameObject goblinPrefab;
    public const int PrefabID = 0;

    #region Constructors

    public Goblin (int spawnId)
    {
        SpawnID = spawnId;
        level = 1;
        displayName = "Goblin";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        goblinPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[PrefabID];
    }

    public Goblin (int spawnId, string name, int level, int maxHp, int currentHp)
    {
        SpawnID = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        goblinPrefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[PrefabID];
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
            isSpawned = true;
            WorldPosition = pos;
            WorldModel = Object.Instantiate(goblinPrefab);
            WorldModel.name = $"Monster,{SpawnID}";
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Goblin death
    /// </summary>
    public override void Death()
    {
        Debug.Log("Goblin is dead.");
    }

    #endregion

}
