using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description The bi-directional link between all the handlers needed for the gameplay of the player
/// </summary>
public class GameManager : MonoBehaviour
{
    public NPCHandler NpcHandler { get; set; }
    public PlayerHandler PlyrHandler { get; set; }

    /// <summary>
    /// Called when the game is launched
    /// </summary>
    void Start()
    {
        NpcHandler = GetComponent<NPCHandler>();
        PlyrHandler = GetComponent<PlayerHandler>();

        //Spawn a goblin for testing purpose
        Goblin newGoblin = new Goblin(NpcHandler.GetFreeSpawnId(), "Goblin", 1, 2, 2);
        NpcHandler.SpawnedNPCs.Add(newGoblin.SpawnID, newGoblin);
        newGoblin.Spawn(new Position(0, 2, -2));

    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {

    }
}
