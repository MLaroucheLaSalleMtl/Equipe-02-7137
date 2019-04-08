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
    //list of the dialogues in this state
    List<Dialogue> Dialogues { get; set; }

    //pointer to know which dialogue index were at
    int dialogueIndex = 0;

    //id of the state
    public int id;

    //the type of the state
    public QuestsInformation.StateTypes Type;

    //amount requiered to finish the state
    public int amountRequiered;

    //current amount (progress) of the state
    public int currentAmount;

    //npc or item to gather to complete the state
    public MonsterInformation.Monsters npcToKill;
    public Item itemToGather;

    //description of what to do in the state
    string description;

    //is the state completed
    bool isCompleted;

    /// <summary>
    /// Instantiates a new state
    /// </summary>
    public QuestState (int id, QuestsInformation.StateTypes type, int amountRequiered, MonsterInformation.Monsters toKill, Item toGather, string description)
    {
        this.id = id;
        this.Type = type;
        this.amountRequiered = amountRequiered;
        this.npcToKill = toKill;
        this.itemToGather = toGather;
        this.description = description;
        Dialogues = new List<Dialogue>();
        dialogueIndex = 0;
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

    /// <summary>
    /// Return a string containing what the player has to do in this state
    /// </summary>
    /// <returns></returns>
    public string GoalDescription()
    {
        return description;
    }

    /// <summary>
    /// Load the dialogues into the list
    /// </summary>
    public void LoadDialogue (Dialogue dialogue)
    {
        Dialogues.Add(dialogue);
    }

    /// <summary>
    /// Next dialogue
    /// </summary>
    /// <returns></returns>
    public Dialogue NextDialogue ()
    {
        if (dialogueIndex + 1 > Dialogues.Count)
        {
            if (Type == QuestsInformation.StateTypes.TALKING_STATE)
            {
                CompleteState();
            }
            return null;
        }
        else
        {
            return Dialogues[dialogueIndex++];
        }
    }

    /// <summary>
    /// Next dialogue
    /// </summary>
    /// <returns></returns>
    public Dialogue PreviousDialogue()
    {
        return dialogueIndex <= 0 ? Dialogues[dialogueIndex] : Dialogues[--dialogueIndex];
    }

    /// <summary>
    /// Quit the dialogue
    /// </summary>
    public void QuitDialogue ()
    {
        dialogueIndex = 0;
    }

    public int GetDialogueIndex ()
    {
        return dialogueIndex;
    }
}
