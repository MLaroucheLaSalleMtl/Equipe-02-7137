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
    private GameObject goblin;

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
        currentHp = maxHp;
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
            Debug.Log("You have spawned a goblin.");
            goblin = Object.Instantiate(goblinPrefab);
            goblin.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
    }

    #endregion

}
