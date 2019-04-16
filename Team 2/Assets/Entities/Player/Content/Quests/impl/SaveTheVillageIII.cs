using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheVillageIII : Quest
{
    private GameManager manager;

    public const string NPC_NAME = "Dreyar";

    public enum StateIds
    {
        AKAI_TALKING,
        GREEN_DRAGON_KILLING,
    }

    /// <summary>
    /// Instantiates a quest for a player
    /// </summary>
    public SaveTheVillageIII(Player player)
    {
        id = QuestsInformation.QuestIds.SAVE_THE_VILLAGE_III;
        name = "Save the Village (III)";
        description = "You need to save the village from the green dragons! Please help the villagers!";
        moneyReward = 300;
        experienceReward = 200;
        itemsReward = null;
        currentStateId = 0;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            return false;
        }
        else
        {
            currentStateId++;
            return true;
        }
    }

    public override void StartQuest()
    {
        CreateStates();
    }

    public override void CreateStates()
    {
        states = new List<QuestState>();
        QuestState stateOne = new QuestState(0, QuestsInformation.StateTypes.TALKING_STATE, 0, 0, null, 
            $"Talk to {NPC_NAME}.");
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Oh finally you're here! I've been waiting for you for a while now!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "I've heard that you're a great killer. Can you help me with something?"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "I need help killing some green dragons, they're buring our city"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "and we really need your help! I tried to kill them, but they're really strong!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Last time I saw them was near the burning island!"));
        states.Add(stateOne);

        QuestState stateTwo = new QuestState(1, QuestsInformation.StateTypes.KILL_STATE, 50, MonsterInformation.Monsters.GREEN_DRAGON, null,
             "Kill 50 green dragons.");
        states.Add(stateTwo);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
