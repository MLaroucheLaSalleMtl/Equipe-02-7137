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
    //prefab of the glowing arrow particle effect
    public GameObject glowingArrowPrefab;
    public GameObject currentArrow;

    //the show more/less button
    public Button showButton;
    public Image showImage;
    public Sprite[] showSprites;

    //the quest panel
    public Transform questPanel;

    //the 2 positions the quest panel has to go when opened or closed
    public float[] questPanelPosX;
    //the game manager
    GameManager manager;

    //all the informations to edit in the quest panel for the current quests
    public Text questNameTxt;
    public Text questDescriptionTxt;
    public Text questGoalTxt;
    public Text questIndexTxt;
    public Text questRewardsTxt;
    public Button questClaimButton;

    //array of bools to know if the player has already completed the quests or not
    bool[] isQuestCompleted;
    //is the reward claimed from each quest
    bool[] isRewardClaimed;
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
        int amountOfQuests = Enum.GetNames(typeof(QuestsInformation.QuestIds)).Length;
        isQuestCompleted = new bool[amountOfQuests];
        isRewardClaimed = new bool[amountOfQuests];
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
            questRewardsTxt.text = currentQuests[questPanelIndex].GetRewards();
            questIndexTxt.text = $"{questPanelIndex + 1}/{currentQuests.Count}";
            int id = (int)currentQuests[questPanelIndex].id;
            if (IsCompleted(id) && !HasReceivedReward(id))
            {
                questClaimButton.interactable = true;
            }
            else
            {
                questClaimButton.interactable = false;
            }
        }
        else
        {
            questNameTxt.text = "No active quest";
            questGoalTxt.text = "";
            questDescriptionTxt.text = "";
            questRewardsTxt.text = "";
            questIndexTxt.text = "1/1";
            questClaimButton.interactable = false;
        }
    }

    /// <summary>
    /// Show a glowing arrow on canvas with a certain position and rotation
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    public void ShowArrow(Vector3 position, Quaternion rotation)
    {
        GameObject arrow = Instantiate(glowingArrowPrefab);
        arrow.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform);
        arrow.transform.localPosition = position;
        arrow.transform.localRotation = rotation;
        if (currentArrow != null)
        {
            Destroy(currentArrow);
        }
        currentArrow = arrow;
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
        if (!IsCompleted(id))
        {
            quest.FinishQuest();
            isQuestCompleted[id] = true;
            DisplayCurrentQuest();
        }
    }

    /// <summary>
    /// Give rewards from a quest
    /// </summary>
    public void GiveReward (int index)
    {
        Quest quest = currentQuests[index];
        int id = (int)quest.id;
        if (!HasReceivedReward(id))
        {
            quest.GiveReward();
            isRewardClaimed[id] = true;
            currentQuests.Remove(quest);
            DisplayCurrentQuest();
            manager.playerHandler.UpdatePlayerBarUI();
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
        DisplayCurrentQuest();
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
    /// Is the quest started ?
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool IsStarted(int index)
    {
        return currentQuests.Find(x => (int)x.id == index) != null;
    }

    /// <summary>
    /// Is the quest completed?
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool IsCompleted(int questId)
    {
        return isQuestCompleted[questId];
    }

    /// <summary>
    /// Has the player received the reward already?
    /// </summary>
    /// <param name="questId"></param>
    /// <returns></returns>
    public bool HasReceivedReward (int questId)
    {
        return isRewardClaimed[questId];
    }

    /// <summary>
    /// Show the next quest in the quest panel
    /// </summary>
    public void NextQuestClick ()
    {
        questPanelIndex = ++questPanelIndex >= currentQuests.Count ? 0 : questPanelIndex;
        DisplayCurrentQuest();
    }

    /// <summary>
    /// Show the previosu quest in the quest panel
    /// </summary>
    public void PreviousQuestClick()
    {
        questPanelIndex = --questPanelIndex < 0 ? currentQuests.Count - 1 : questPanelIndex;
        DisplayCurrentQuest();
    }

    /// <summary>
    /// Give rewards to the player for a certain quest
    /// </summary>
    public void ClaimRewardClick()
    {
        GiveReward(questPanelIndex);
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
