using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheVillageIV : Quest
{
    private GameManager manager;

    public const string NPC_NAME = "Ganfaul";

    public enum StateIds
    {
        GANFAUL_TALKING,
        SKELETON_KILLING,
        GANFAUL_TALKING2,
        SKELETON_KILLING2,
    }

    /// <summary>
    /// Instantiates a quest for a player
    /// </summary>
    public SaveTheVillageIV(Player player)
    {
        id = QuestsInformation.QuestIds.SAVE_THE_VILLAGE_IV;
        name = "Save the Village (IV)";
        description = "You need to save the village from the skeletons! Please help the villagers!";
        moneyReward = 450;
        experienceReward = 225;
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
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "Look at all those skeletons... pathetic... really.."));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "I hate skeletons.. Can you help me get rid of them?"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "They make me anxious.. If you help me, I'll give you a really"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "great reward. You'll also get experience from killing them"));
        stateOne.LoadDialogue(new Dialogue(NPC_NAME, "So it's a win win for you. Let's get the killing going!"));
        states.Add(stateOne);

        QuestState stateTwo = new QuestState(1, QuestsInformation.StateTypes.KILL_STATE, 15, MonsterInformation.Monsters.SKELETON, null,
             "Kill 15 skeletons.");
        states.Add(stateTwo);

        QuestState stateThree = new QuestState(2, QuestsInformation.StateTypes.TALKING_STATE, 0, 0, null,
    $"Go back to see {NPC_NAME}.");
        stateThree.LoadDialogue(new Dialogue(NPC_NAME, "I see that you've killed quite a bunch of skeletons."));
        stateThree.LoadDialogue(new Dialogue(NPC_NAME, "But... open your eyes... can't you see that there are much"));
        stateThree.LoadDialogue(new Dialogue(NPC_NAME, "Much much more left to kill? The field is covered with skeletons..."));
        stateThree.LoadDialogue(new Dialogue(NPC_NAME, "Let's go adventurer, go back to killing those nasty creatures!"));
        states.Add(stateThree);

        QuestState stateFour = new QuestState(3, QuestsInformation.StateTypes.KILL_STATE, 75, MonsterInformation.Monsters.SKELETON, null,
             "Kill 75 more skeletons.");
        states.Add(stateFour);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
