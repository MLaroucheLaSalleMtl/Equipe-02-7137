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
    public enum PlayerBarTextIds
    {
        USERNAME,
        HP,
        MONEY,
        LEVEL,
        PERCENTAGE_LEVEL,
    }

    /// <summary>
    /// The ids of the masks for the player bar
    /// </summary>
    public enum PlayerBarMaskIds
    {
        HP,
        XP,
    }

    //bi directional link to the game manager
    GameManager Manager { get; set; }
    //The texts in the ui
    [SerializeField] Text[] PlayerBarTexts;
    [SerializeField] Image[] PlayerBarMasks;

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("HealOvertime", 1, 1);
    }

    /// <summary>
    /// Update the masks of the player bar
    /// </summary>
    private void UpdateBarMasks ()
    {
        for (int index = 0; index < PlayerBarMasks.Length; index++)
        {
            switch (index)
            {
                case (int)PlayerBarMaskIds.HP:
                    float currentHp = Manager.player.CurrentHp;
                    float maxHp = Manager.player.MaxHP;
                    PlayerBarMasks[index].fillAmount = currentHp / maxHp;
                    break;
                case (int)PlayerBarMaskIds.XP:
                    float experience = Manager.player.Experience - Manager.player.GetXpToLevelUp(Manager.player.Level - 1);
                    float xpToUp = Manager.player.GetXpToLevelUp(Manager.player.Level) - Manager.player.GetXpToLevelUp(Manager.player.Level - 1);
                    PlayerBarMasks[index].fillAmount = experience / xpToUp;
                    break;
            }
        }
    }

    /// <summary>
    /// Update the texts of the player bar
    /// </summary>
    private void UpdateBarTexts()
    {
        for (int index = 0; index < PlayerBarTexts.Length; index++)
        {
            switch (index)
            {
                case (int)PlayerBarTextIds.USERNAME:
                    PlayerBarTexts[index].text = $"{Manager.player.DisplayName}";
                    break;
                case (int)PlayerBarTextIds.HP:
                    PlayerBarTexts[index].text = $"{Manager.player.CurrentHp} / {Manager.player.MaxHP}";
                    break;
                case (int)PlayerBarTextIds.MONEY:
                    PlayerBarTexts[index].text = $"{Manager.player.Money}";
                    break;
                case (int)PlayerBarTextIds.LEVEL:
                    PlayerBarTexts[index].text = $"Level: {Manager.player.Level}";
                    break;
                case (int)PlayerBarTextIds.PERCENTAGE_LEVEL:
                    float experience = Manager.player.Experience - Manager.player.GetXpToLevelUp(Manager.player.Level - 1);
                    float xpToUp = Manager.player.GetXpToLevelUp(Manager.player.Level) - Manager.player.GetXpToLevelUp(Manager.player.Level - 1);
                    PlayerBarTexts[index].text = $"{Mathf.Floor(experience / xpToUp * 100)} %";
                    break;
            }
        }
    }

    /// <summary>
    /// Update the player bar
    /// </summary>
    public void UpdatePlayerBarUI ()
    {
        UpdateBarTexts();
        UpdateBarMasks();
    }

    /// <summary>
    /// Create a new player and update the player UI
    /// </summary>
    public void CreatePlayer (string name, int level, int maxhp, int strength, int intelligence, int dexterity, int defence, int money, PlayerClass playerclass, GameObject playerModel)
    {
        Manager.player = new Player(name, level, maxhp, strength, intelligence, dexterity, defence, money, playerclass, playerModel);
        //for (int index = 0; index < ClassesInformation.AmountOfAttacks; index++)
        //{
        //    Manager.combatHandler.AttacksCooldown[index] = index + 1;
        //}
        UpdatePlayerBarUI();
    }

    /// <summary>
    /// Damage the player
    /// </summary>
    /// <param name="amount"></param>
    public void DamagePlayer (int amount,bool ignorDeffence=false)
    {
        float dmgMod = 100;
        if(!ignorDeffence)
        {
            foreach(Skill s in Manager.player.Class.UnlockedSkills)
            {
                dmgMod -= s.DefModifyer;
            }
        }
        dmgMod /= 100;
        Manager.player.RemoveHp((int)(amount*dmgMod));
        UpdatePlayerBarUI();
    }

    /// <summary>
    /// Heal the player
    /// </summary>
    /// <param name="amount"></param>
    public void HealPlayer(int amount=-1)
    {
        if(amount<0)
        {
            Manager.player.GiveHp(Manager.player.MaxHP-Manager.player.CurrentHp);
        }
        else
        {
            Manager.player.GiveHp(amount);
        }
        UpdatePlayerBarUI();
    }
    public void HealPlayer(int amount,bool capAtMax)
    {
        
        if(capAtMax && Manager.player.CurrentHp + amount >= Manager.player.MaxHP)
        {
            Manager.player.GiveHp(Manager.player.MaxHP- Manager.player.CurrentHp);
            return;
        }
        Manager.player.GiveHp(amount);
    }

    private void HealOvertime()
    {
        HealPlayer((int)(Manager.player.MaxHP / 100), true);
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
