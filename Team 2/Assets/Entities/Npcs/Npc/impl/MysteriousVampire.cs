using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 08 AVR 2019
/// @description The mysterious vampire npc
/// </summary>
public class MysteriousVampire : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.MYSTERIOUS_VAMPIRE;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        if (manager.questHandler.CanStart((int)QuestsInformation.QuestIds.SAVE_THE_VILLAGER_I))
        {
            manager.questHandler.StartQuest((int)QuestsInformation.QuestIds.SAVE_THE_VILLAGER_I);
            foreach (Quest quest in manager.questHandler.currentQuests)
            {
                if (quest.id == QuestsInformation.QuestIds.SAVE_THE_VILLAGER_I)
                {
                    manager.dialogueHandler.StartDialogue(quest);
                }
            }
        }
    }

}
