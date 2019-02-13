﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description Handles everything related to npcs
/// </summary>
public class NPCHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }

    //all the prefabs of the npcs
    public GameObject[] npcPrefabs;

    //list that contains all te npcs currently spawned
    public Dictionary<int, NPC> SpawnedNPCs { get; set; }

    /// <summary>
    /// Returns the smallest spawn id available
    /// </summary>
    /// <returns></returns>
    public int GetFreeSpawnId ()
    {
        int spawnId = 0;
        while (SpawnedNPCs.ContainsKey(spawnId))
        {
            spawnId++;
        }
        return spawnId;
    }

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnedNPCs = new Dictionary<int, NPC>();
    }

    /// <summary>
    /// Called at the start of the game
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        
    }
}
