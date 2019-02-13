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
    public NPCHandler npcHandler { get; set; }
    public PlayerHandler playerHandler { get; set; }
    public ItemHandler itemHandler { get; set; }

    /// <summary>
    /// Called when the game is launched
    /// </summary>
    void Start()
    {
        npcHandler = GetComponent<NPCHandler>();
        playerHandler = GetComponent<PlayerHandler>();
        itemHandler = GetComponent<ItemHandler>();

        //Spawn a goblin for testing purpose
        Goblin newGoblin = new Goblin(npcHandler.GetFreeSpawnId(), "Goblin", 1, 2, 2);
        npcHandler.SpawnedNPCs.Add(newGoblin.SpawnID, newGoblin);
        newGoblin.Spawn(new Position(0, 0, -2));
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {

    }
}
