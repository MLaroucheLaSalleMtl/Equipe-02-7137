using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 25 MARS 2019
/// @description The dark knight npc
/// </summary>
public class DarkKnight : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.DARK_KNIGHT;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        if (manager.questHandler.CanStart((int)QuestsInformation.QuestIds.TUTORIAL_QUEST))
        {
            manager.questHandler.StartQuest((int)QuestsInformation.QuestIds.TUTORIAL_QUEST);
            foreach (Quest quest in manager.questHandler.currentQuests)
            {
                if (quest.id == QuestsInformation.QuestIds.TUTORIAL_QUEST)
                {
                    manager.dialogueHandler.StartDialogue(quest);
                }
            }
        }
    }

}
