using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 24 MARS 2019
/// @description Handles everything related to dialogues
/// </summary>
public class DialogueHandler : MonoBehaviour
{

    GameManager manager;
    public Animator dialoguePanelAnimator;
    public Text nameText;
    public Text dialogueText;
    Quest currentQuest;
    Dialogue toDisplay;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();

    }

    public void QuitDialogue()
    {
        if (currentQuest == null)
        {
            return;
        }
        currentQuest.GetCurrentState().QuitDialogue();
        currentQuest = null;
        dialoguePanelAnimator.SetBool("IsOpen", false);
    }

    public void StartDialogue(Quest quest)
    {
        if (currentQuest != null)
        {
            return;
        }
        currentQuest = quest;
        dialoguePanelAnimator.SetBool("IsOpen", true);
        NextDialogueClick();
    }

    public void NextDialogueClick()
    {
        if (currentQuest == null)
        {
            return;
        }
        QuestState state = currentQuest.GetCurrentState();

        //arrows for tutorial quest
        if (currentQuest.id == QuestsInformation.QuestIds.TUTORIAL_QUEST)
        {
            int index = state.GetDialogueIndex();
            TutorialQuestArrow(index);
        }

        toDisplay = state.NextDialogue();
        if (toDisplay == null)
        {
            if (state.IsCompleted())
            {
                manager.questHandler.NextState((int)currentQuest.id);
            }
            QuitDialogue();
        }
        else
        {
            UpdateDialogueUI();
        }
    }

    public void PreviousDialogueClick()
    {
        if (currentQuest == null)
        {
            return;
        }
        Dialogue previous = currentQuest.GetCurrentState().PreviousDialogue();
        if (toDisplay == previous)
        {
            return;
        }
        toDisplay = previous;
        UpdateDialogueUI();
    }

    public void UpdateDialogueUI ()
    {
        nameText.text = $"{toDisplay.Name}";
        StopAllCoroutines();
        StartCoroutine(TypeDialogue(toDisplay.Text));
        
    }

    IEnumerator TypeDialogue (string text)
    {
        dialogueText.text = "";
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void TutorialQuestArrow (int dialogueIndex)
    {
        if (dialogueIndex > 0 && dialogueIndex < 5)
        {
            manager.questHandler.ShowArrow(TutorialQuest.arrowPositions[dialogueIndex - 1], Quaternion.Euler(TutorialQuest.arrowRotations[dialogueIndex - 1]));
        }
        else
        {
            manager.questHandler.HideArrow();
        }
    }

}
