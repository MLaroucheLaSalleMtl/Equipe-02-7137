using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 11 AVR 2019
/// @description The Dreyar npc
/// </summary>
public class Dreyar : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.DREYAR;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        if (manager.questHandler.CanStart((int)QuestsInformation.QuestIds.SAVE_THE_VILLAGE_III))
        {
            manager.questHandler.StartQuest((int)QuestsInformation.QuestIds.SAVE_THE_VILLAGE_III);
            foreach (Quest quest in manager.questHandler.currentQuests)
            {
                if (quest.id == QuestsInformation.QuestIds.SAVE_THE_VILLAGE_III)
                {
                    manager.dialogueHandler.StartDialogue(quest);
                }
            }
        }
    }

}
