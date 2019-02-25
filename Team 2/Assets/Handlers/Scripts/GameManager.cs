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

    public Player player { get; set; }
    public NPCHandler npcHandler { get; set; }
    public PlayerHandler playerHandler { get; set; }
    public ItemHandler itemHandler { get; set; }
    public CombatHandler combatHandler { get; set; }

    /// <summary>
    /// Called when the game is launched
    /// </summary>
    void Start()
    {
        player = new Player();
        npcHandler = GetComponent<NPCHandler>();
        playerHandler = GetComponent<PlayerHandler>();
        itemHandler = GetComponent<ItemHandler>();
        combatHandler = GetComponent<CombatHandler>();

        player.WorldModel = GameObject.Find("Player");
        player.Class = new WarriorClass(Instantiate(combatHandler.hitboxesPrefab[(int)ClassesInformation.ClassesId.WARRIOR], player.WorldModel.transform));
        
        //Spawn monsters for testing purposes
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(-2, 0, 0), "Goblin", 5, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(2, 0, 0), "Impling", 5, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(6, 0, 0), "Shell Crab", 5, 4, 4);
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            combatHandler.Attack(npcHandler.SpawnedNPCs[0]);
        }
    }
}
