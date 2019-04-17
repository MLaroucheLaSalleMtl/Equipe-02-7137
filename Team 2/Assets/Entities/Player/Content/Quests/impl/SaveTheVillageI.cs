using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheVillageI : Quest
{
    private GameManager manager;

    public const string NPC_NAME = "Mysterious Vampire";

    public enum StateIds
    {
        VAMPIRE_TALKING,
        RED_BOAR_KILLING,
    }

    /// <summary>
    /// Instantiates a quest for a player
    /// </summary>
    public SaveTheVillageI(Player player)
    {
        id = QuestsInformation.QuestIds.SAVE_THE_VILLAGE_I;
        name = "Save the Village (I)";
        description = "You need to save the village from the red boars! Please help the villagers!";
        moneyReward = 200;
        experienceReward = 150;
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
            "Talk to the Mysterious Vampire.");
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Oh! I see you have a weapon, we need your help adventurer!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "The city is in danger... all those red boars are coming during night time to destroy houses"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "and sometimes, even eat villagers alive!! No one can stop them! There are so much of them!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Please, adventurer, help us!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "We saw them last time at the top of the hills, maybe you'll find them there."));
        states.Add(stateOne);

        QuestState stateTwo = new QuestState(1, QuestsInformation.StateTypes.KILL_STATE, 25, MonsterInformation.Monsters.RED_BOAR, null,
             "Kill 25 red boars.");
        states.Add(stateTwo);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
