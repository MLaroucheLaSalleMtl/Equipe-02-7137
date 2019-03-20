using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 20 MARS 2019
/// @description A state of a quest
/// </summary>
public class QuestState 
{
    //id of the state
    public int id;

    //the type of the state
    protected QuestsInformation.StateTypes type;

    //amount requiered to finish the state
    public int amountRequiered;

    //current amount (progress) of the state
    public int currentAmount;

    //npc or item to gather to complete the state
    public MonsterInformation.MonsterNames npcToKill;
    public Item itemToGather;

    //description of what to do in the state
    public string description;

    //is the state completed
    public bool isCompleted;

    /// <summary>
    /// Instantiates a new state
    /// </summary>
    public QuestState (int id, QuestsInformation.StateTypes type, int amountRequiered, MonsterInformation.MonsterNames toKill, Item toGather, string description)
    {
        this.id = id;
        this.type = type;
        this.amountRequiered = amountRequiered;
        this.npcToKill = toKill;
        this.itemToGather = toGather;
        this.description = description;
    }

    /// <summary>
    /// Is the state completed?
    /// </summary>
    /// <returns></returns>
    public bool IsCompleted()
    {
        if (currentAmount >= amountRequiered)
        {
            isCompleted = true;
        }
        return isCompleted;
    }

    /// <summary>
    /// Complete the state
    /// </summary>
    public void CompleteState()
    {
        isCompleted = true;
    }
}
