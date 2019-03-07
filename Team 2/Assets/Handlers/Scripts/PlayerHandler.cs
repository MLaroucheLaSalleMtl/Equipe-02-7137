using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 12 February 2019
/// @description Handles everything related to the player
/// </summary>
public class PlayerHandler : MonoBehaviour
{

    /// <summary>
    /// The ids of the texts in the array
    /// </summary>
    public enum PlayerBarTextId
    {
        USERNAME,
        HP,
        MONEY,
        LEVEL,
        PERCENTAGE_LEVEL,
    }

    //bi directional link to the game manager
    GameManager Manager { get; set; }
    //The texts in the ui
    [SerializeField] Text[] PlayerBarTexts;

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Update the player bar
    /// </summary>
    public void UpdatePlayerBarUI ()
    {
        for (int index = 0; index < PlayerBarTexts.Length; index++)
        {
            switch (index)
            {
                case (int)PlayerBarTextId.USERNAME:
                    PlayerBarTexts[index].text = $"{Manager.player.DisplayName}";
                    break;
                case (int)PlayerBarTextId.HP:
                    PlayerBarTexts[index].text = $"HP: {Manager.player.CurrentHp}";
                    break;
                case (int)PlayerBarTextId.MONEY:
                    PlayerBarTexts[index].text = $"Money: {Manager.player.Money}$";
                    break;
                case (int)PlayerBarTextId.LEVEL:
                    PlayerBarTexts[index].text = $"Level: {Manager.player.Level}";
                    break;
                case (int)PlayerBarTextId.PERCENTAGE_LEVEL:
                    PlayerBarTexts[index].text = $"Till level up: {(Manager.player.Experience * 100) / Manager.player.GetXpToLevelUp(Manager.player.Level)}%";
                    break;
            }
        }
    }

    /// <summary>
    /// Create a new player and update the player UI
    /// </summary>
    public void CreatePlayer (string name, int level, int maxhp, int strength, int intelligence, int dexterity, int defence, int money, PlayerClass playerclass, GameObject playerModel)
    {
        Manager.player = new Player(name, level, maxhp, strength, intelligence, dexterity, defence, money, playerclass, playerModel);
        for (int index = 0; index < ClassesInformation.AmountOfAttacks; index++)
        {
            Manager.combatHandler.AttacksCooldown[index] = index + 1;
        }
        UpdatePlayerBarUI();
    }

    /// <summary>
    /// Called at the start of the game
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        
    }
}
