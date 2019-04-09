using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheVillageII : Quest
{
    private GameManager manager;

    public const string NPC_NAME = "Akai";

    public enum StateIds
    {
        AKAI_TALKING,
        GREEN_BOAR_KILLING,
    }

    /// <summary>
    /// Instantiates a quest for a player
    /// </summary>
    public SaveTheVillageII(Player player)
    {
        id = QuestsInformation.QuestIds.SAVE_THE_VILLAGE_II;
        name = "Save the Village (II)";
        description = "You need to save the village from the green boars! Please help the villagers!";
        moneyReward = 300;
        experienceReward = 400;
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
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Psss! Hey you! Yes you! Come here!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "There are a lot of green boars roaming around.. and I am unable"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "to kill them all on my own.. I need so help to get rid of them..."));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "They attack the villagers and steal our stuff so we really need your help!"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "I am killing them near the bottom of the hills, meet me there!"));
        states.Add(stateOne);

        QuestState stateTwo = new QuestState(1, QuestsInformation.StateTypes.KILL_STATE, 30, MonsterInformation.Monsters.GREEN_BOAR, null,
             "Kill 30 green boars.");
        states.Add(stateTwo);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
