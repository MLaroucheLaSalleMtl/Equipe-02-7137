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
    public Transform questPanel;
    public float[] questPanelPosX;

    //if the quest tab is opened or not
    public bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// When clicking on the show button
    /// </summary>
    public void ShowButtonClick ()
    {
        int index = isOpened ? 1 : 0;
        showImage.sprite = showSprites[index];
        questPanel.position = new Vector3(questPanelPosX[index], questPanel.position.y, questPanel.position.z);
        isOpened = !isOpened;
    }

}
