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
        player.Class = new WarriorClass();
        
        //Spawn monsters for testing purposes
        npcHandler.SpawnNPC(NPCInformation.NPCNames.GOBLIN, new Position(-2, 31, 0), "Goblin", 5, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.IMPLING, new Position(2, 31, 0), "Impling", 5, 4, 4);
        npcHandler.SpawnNPC(NPCInformation.NPCNames.SHELLCRAB, new Position(6, 31, 0), "Shell Crab", 5, 4, 4);
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
