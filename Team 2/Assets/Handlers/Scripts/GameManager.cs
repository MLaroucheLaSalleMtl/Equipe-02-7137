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
        npcHandler = GetComponent<NPCHandler>();
        playerHandler = GetComponent<PlayerHandler>();
        itemHandler = GetComponent<ItemHandler>();
        combatHandler = GetComponent<CombatHandler>();

        playerHandler.CreatePlayer("Satucre", 1, 10, 1, 0, 0, 0, 150, new WarriorClass(), GameObject.Find("Player"));

        //Spawn monsters for testing purposes
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(-11, 31, -5), "Goblin", 1, 2, 2);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(8, 31, 17), "Impling", 1, 2, 2);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(23, 31, -5), "Shell Crab", 1, 2, 2);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(32, 31, 16), "Goblin", 1, 2, 2);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(2, 31, 0-24), "Impling", 1, 2, 2);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(-15, 31, 16), "Shell Crab", 1, 2, 2);

        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(-44, 31, 46), "Goblin", 2, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(-66, 31, 2), "Impling", 2, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(-54, 31,-31), "Shell Crab", 2, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(61, 31, -29), "Goblin", 2, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(96, 31, 33), "Impling", 2, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(89, 31, -2), "Shell Crab", 2, 4, 4);

        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(-121, 31, 37), "Goblin", 3, 6, 6);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(-128, 31, -24), "Impling", 3, 6, 6);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(-128, 31, -58), "Shell Crab", 3, 6, 6);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(154, 31, -50), "Goblin", 3, 6, 6);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(164, 31, -8), "Impling", 3, 6, 6);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(164, 31, 45), "Shell Crab", 3, 6, 6);
    }

    /// <summary>
    /// When the users clicks with his mouse on the first ability
    /// </summary>
    public void FirstAbilityButtonClick ()
    {
        combatHandler.Attack(0);
    }

    /// <summary>
    /// When the users clicks with his mouse on the second ability
    /// </summary>
    public void SecondAbilityButtonClick()
    {
        combatHandler.Attack(1);
    }

    /// <summary>
    /// When the users clicks with his mouse on the third ability
    /// </summary>
    public void ThirdAbilityButtonClick()
    {
        combatHandler.Attack(2);
    }

    /// <summary>
    /// When the users clicks with his mouse on the fourth ability
    /// </summary>
    public void FourthAbilityButtonClick()
    {
        combatHandler.Attack(3);
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            combatHandler.Attack((int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            combatHandler.Attack((int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            combatHandler.Attack((int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            combatHandler.Attack((int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK);
        }
    }
}
