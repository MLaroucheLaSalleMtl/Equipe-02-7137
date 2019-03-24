using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 19 MARS 2019
/// @description Handles everything related to quests
/// </summary>
public class QuestHandler : MonoBehaviour
{

    //the show more/less button
    public Button showButton;
    public Image showImage;
    public Sprite[] showSprites;

    //the quest panel
    public Transform questPanel;

    //the 2 positions the quest panel has to go when opened or closed
    public float[] questPanelPosX;
    //the game manager
    public GameManager manager;

    //all the informations to edit in the quest panel for the current quests
    public Text questNameTxt;
    public Text questDescriptionTxt;
    public Text questGoalTxt;
    public Text questIndexTxt;

    //array of bools to know if the player has already completed the quests or not
    public bool[] isQuestCompleted;
    //current quests
    public List<Quest> currentQuests;
    //if the quest tab is opened or not
    public bool isOpened;
    //the index of which quest the player is looking at in the quest panel
    public int questPanelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();
        currentQuests = new List<Quest>();
        isOpened = false;
        isQuestCompleted = new bool[Enum.GetNames(typeof(QuestsInformation.QuestIds)).Length];
        DisplayCurrentQuest();
    }

    /// <summary>
    /// Display the current quest state in the UI
    /// </summary>
    public void DisplayCurrentQuest ()
    {
        if (currentQuests.Count > 0)
        {
            questNameTxt.text = currentQuests[questPanelIndex].name;
            questDescriptionTxt.text = currentQuests[questPanelIndex].description;
            questGoalTxt.text = currentQuests[questPanelIndex].GetCurrentState().GoalDescription();
            questIndexTxt.text = $"{questPanelIndex + 1}/{currentQuests.Count}";
        }
        else
        {
            questNameTxt.text = "No active quest";
            questGoalTxt.text = "";
            questDescriptionTxt.text = "";
            questIndexTxt.text = "1/1";
        }
    }

    /// <summary>
    /// Start a quest
    /// </summary>
    public bool StartQuest (int id)
    {
        if (isQuestCompleted[id])
        {
            return false;
        }
        switch (id)
        {
            case (int)QuestsInformation.QuestIds.TUTORIAL_QUEST:
                currentQuests.Add(new TutorialQuest(manager.player));
                break;
        }
        DisplayCurrentQuest();
        return true;
    }

    /// <summary>
    /// Finish a quest
    /// </summary>
    public void FinishQuest (Quest quest, int id)
    {
        if (!isQuestCompleted[id])
        {
            quest.FinishQuest();
            currentQuests.Remove(quest);
            isQuestCompleted[id] = true;
        }
    }

    /// <summary>
    /// Next state of a quest
    /// </summary>
    /// <param name="id"></param>
    public void NextState(int id)
    {
        Quest quest = currentQuests.Find(x => (int)x.id == id);
        if (quest == null)
        {
            Debug.LogError("Trying to go the next state of a non started/completed quest.");
            return;
        }
        bool isFinished = quest.NextState();
        if (isFinished)
        {
            FinishQuest(quest, id);
        }
    }

    /// <summary>
    /// Check for any quests progression
    /// </summary>
    public void CheckQuestsProgression (Monster monster = null)
    {
        if (currentQuests.Count > 0)
        {
            for (int index = 0; index < currentQuests.Count; index++)
            {
                QuestState state = currentQuests[index].GetCurrentState();
                if (state.npcToKill == monster.Id)
                {
                    state.currentAmount++;
                    if (state.IsCompleted())
                    {
                        NextState((int)currentQuests[index].id);
                        manager.playerHandler.UpdatePlayerBarUI();
                    }
                }
            }
        }
        DisplayCurrentQuest();
    }

    /// <summary>
    /// When clicking on the show button
    /// </summary>
    public void ShowButtonClick ()
    {
        int index = isOpened ? 1 : 0;
        showImage.sprite = showSprites[index];
        questPanel.localPosition = new Vector3(questPanelPosX[index], 0f, 0f);
        isOpened = !isOpened;
    }

}
