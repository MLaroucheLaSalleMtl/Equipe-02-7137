using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest : Quest
{
    public static Vector3[] arrowPositions;
    public static Vector3[] arrowRotations;
    private GameManager manager;

    public enum TutorialQuestStateIds
    {
        DARK_KNIGHT_TALKING,
        SKELETON_KILLING,
    }

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
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.player = player;
        StartQuest();
        arrowPositions = new Vector3[4] { new Vector3(0, -125, 0), new Vector3(-175, -150, 0), new Vector3(180, -55, 0) , new Vector3(-335, 48, 0) };
        arrowRotations = new Vector3[4] { new Vector3(0, 0, 270), new Vector3(0, 0, 215), new Vector3(0, 0, 315), new Vector3(0, 0, 180)};
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
            if (currentStateId == (int)TutorialQuestStateIds.SKELETON_KILLING)
            {
                manager.monsterHandler.SpawnMonster(MonsterInformation.Monsters.IMPLING, new Position(34, 31, -60), "Skeleton", 1, 5, 5);
                manager.monsterHandler.SpawnMonster(MonsterInformation.Monsters.RED_DRAGON, new Position(2, 31, -15), "Skeleton", 1, 5, 5);
                manager.monsterHandler.SpawnMonster(MonsterInformation.Monsters.BLUE_BOAR, new Position(-26, 31, -43), "Skeleton", 1, 5, 5);
            }
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
        QuestState stateOne = new QuestState(0, QuestsInformation.StateTypes.TALKING_STATE, 0, MonsterInformation.Monsters.SKELETON, null, 
            "Talk to the Dark Knight. He will explain you how to play the game.");
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "Hello adventurer. Let me show you quickly how to play the game."));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "First, you have your ability bar at the middle bottom. You can use" +
            " those abilities to kill monsters."));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "You can use WASD on your keyboard to move around. Also at the bottom left," +
            " you have your player statistics. Like your cash, experience, level, etc. "));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "At the bottom right, you have the minimap, you get an overview of" +
            " what the world reserves you."));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "Lastly, in the middle left, you have your quest tab. You can click" +
            " the plus and minus sign to show or hide the tab. Make sure to complete quests as they give good rewards!"));
        stateOne.LoadDialogue(new Dialogue("Dark Knight", "Now adventurer, please go kill 3 skeletons! That's your first quest! Good luck!"));
        states.Add(stateOne);

        QuestState stateTwo = new QuestState(1, QuestsInformation.StateTypes.KILL_STATE, 3, MonsterInformation.Monsters.SKELETON, null,
    "Kill 3 skeletons.");
        states.Add(stateTwo);
    }

    public override string GetRewards()
    {
        return $"-{experienceReward} XP \n-{moneyReward}$";
    }
}
