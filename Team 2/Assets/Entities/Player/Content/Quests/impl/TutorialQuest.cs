using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest : Quest
{

    /// <summary>
    /// Instantiates a tutorial quest for a player
    /// </summary>
    public TutorialQuest(Player player)
    {
        id = QuestsInformation.QuestIds.TUTORIAL_QUEST;
        name = "Tutorial";
        description = "This quest explains you how to play the game.";
        moneyReward = 150;
        experienceReward = 100;
        itemsReward = null;
        currentStateId = 0;
        this.player = player;
        StartQuest();
    }

    public override void FinishQuest()
    {
        //something dialogue or etc.
    }

    public override QuestState GetCurrentState()
    {
        return states[currentStateId];
    }

    public override void GiveReward()
    {
        player.Experience += experienceReward;
        player.Money += moneyReward;
        //to do add items to inventory
    }

    public override bool NextState()
    {
        if (currentStateId + 1 >= states.Count)
        {
            return true;
        }
        else
        {
            currentStateId++;
            return false;
        }
    }

    public override void StartQuest()
    {
        CreateStates();
    }

    public override void CreateStates()
    {
        states = new List<QuestState>();
        QuestState stateOne = new QuestState(0, QuestsInformation.StateTypes.KILL_STATE, 3, MonsterInformation.Monsters.SKELETON, null, 
            "Kill 3 skeletons.");
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "Hello adventurer. Let me show quickly how to play the game."));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "First, you have your ability bar at the middle bottom."));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "Use your abilities to kill 3 skeletons. Good luck! "));
        states.Add(stateOne);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
