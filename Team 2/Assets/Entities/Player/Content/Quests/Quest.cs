using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 19 MARS 2019
/// @description The abstract design of a quest a player can do for rewards, etc.
/// </summary>
public abstract class Quest
{
    //id of the quest
    public QuestsInformation.QuestIds id;

    //player the quest has been assigned to
    public Player player;

    //name of the quest
    public string name;

    //description of the quest
    public string description;

    //money reward from the quest
    public int moneyReward;

    //the experience reward
    public int experienceReward;

    //items reward
    public List<ItemData> itemsReward;

    //states of the quest
    public List<QuestState> states;

    //current state id of the quest
    public int currentStateId;



    //give the reward when completing the quest
    public abstract void GiveReward();

    //execute all actions needed when finshing the quest
    public abstract void FinishQuest();

    //start the quest
    public abstract void StartQuest();

    //load the next state of the quest, if its the end of the quest, return true, if not, return false
    public abstract bool NextState();

    //get the current state of the quest
    public abstract QuestState GetCurrentState();

    //creates the states and add them to the property
    public abstract void CreateStates();

    //get the formatted string reward
    public abstract string GetRewards();
}
