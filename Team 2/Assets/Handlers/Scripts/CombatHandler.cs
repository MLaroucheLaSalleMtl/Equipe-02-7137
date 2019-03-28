using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @author Samuel Paquette
/// @date 25 February 2019
/// @description Handles everything related to the combat
/// </summary>
public class CombatHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }
    GameObject CurrentHitbox { get; set; }
    public List<Monster> NpcsCurrentlyInHitbox { get; set; }

    //the cooldown of the attacks of the player
    public float[] AttacksCooldown { get; set; }

    //the cooldown left on each attack of the player
    public float[] TimeLeftOnCooldown { get; set; }

    //the text field of the cooldown in the ui
    [SerializeField] private Text[] CooldownTexts;
    
    //hitboxes for the classes
    public Animator[] attacksAnimator;

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        NpcsCurrentlyInHitbox = new List<Monster>();


        AttacksCooldown = new float[ClassesInformation.AmountOfAttacks];
        TimeLeftOnCooldown = new float[ClassesInformation.AmountOfAttacks];
    }

    /// <summary>
    /// Checks if we can attack the npc passed in parameters
    /// </summary>
    /// <param name="npcToAttack"></param>
    /// <returns></returns>
    public bool CanAttack (Monster npcToAttack)
    {
        switch (Manager.player.Class.Id)
        {
            case ClassesInformation.ClassesId.WARRIOR:
                if (Vector3.Distance(Manager.player.WorldModel.transform.position, npcToAttack.WorldModel.transform.position) <= Manager.player.Class.Range)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    /// <summary>
    /// Player attacks a npc
    /// </summary>
    /// <param name="npcToAttack"></param>
    public void Attack (int keyIndex = -1)
    {
        //-1 = not attacking
        if (keyIndex == -1 || Manager.player.IsAttacking)
        {
            return;
        }
        switch (Manager.player.Class.Id)
        {
            case ClassesInformation.ClassesId.WARRIOR:
                WarriorAttack(keyIndex);
                break;
        }
    }

    /// <summary>
    /// Attack for the warrior class
    /// </summary>
    public void WarriorAttack (int keyIndex)
    {
        WarriorClass playerClass = Manager.player.Class as WarriorClass;
        switch (keyIndex)
        {
            case (int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK:

                if (CanUseAttack((int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK))
                {
                    CurrentHitbox = GameObject.Find("BasicAttackHitbox");
                    playerClass.BasicAttack(Manager.combatHandler.NpcsCurrentlyInHitbox.ToArray());
                    TimeLeftOnCooldown[(int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK] = AttacksCooldown[(int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK];
                    StartCoroutine(AttackChainingInterval(1.25f));
                }
                break;
            case (int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK:
                if (CanUseAttack((int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK))
                {
                    CurrentHitbox = GameObject.Find("SwingAttackHitbox");
                    playerClass.SwingAttack(Manager.combatHandler.NpcsCurrentlyInHitbox.ToArray());
                    TimeLeftOnCooldown[(int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK] = AttacksCooldown[(int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK];
                    StartCoroutine(AttackChainingInterval(1.75f));
                }
                break;
            case (int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK:
                if (CanUseAttack((int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK))
                {
                    CurrentHitbox = GameObject.Find("JumpAttackHitbox");
                    playerClass.JumpAttack(Manager.combatHandler.NpcsCurrentlyInHitbox.ToArray());
                    TimeLeftOnCooldown[(int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK] = AttacksCooldown[(int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK];
                    StartCoroutine(AttackChainingInterval(2f));
                    Debug.Log(Manager.player.Class.UnlockedSkills[0]);
                }
                break;
            case (int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK:
                if (CanUseAttack((int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK))
                {
                    CurrentHitbox = GameObject.Find("DoubleSwingAttackHitbox");
                    playerClass.DoubleSwingAttack(Manager.combatHandler.NpcsCurrentlyInHitbox.ToArray());
                    TimeLeftOnCooldown[(int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK] = AttacksCooldown[(int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK];
                    StartCoroutine(AttackChainingInterval(3.5f));
                }
                break;
        }
        
    }

    /// <summary>
    /// Checks if the player can use X attack
    /// </summary>
    /// <returns></returns>
    public bool CanUseAttack(int attackIndex)
    {
        return TimeLeftOnCooldown[attackIndex] <= 0f;
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {

        //Reduce cooldown
        for (int index = 0; index < ClassesInformation.AmountOfAttacks; index++)
        {
            if (TimeLeftOnCooldown[index] <= 0f)
            {
                TimeLeftOnCooldown[index] = 0f;
            }
            else
            {
                TimeLeftOnCooldown[index] -= Time.deltaTime;
            }
            if (TimeLeftOnCooldown[index] <= 0f)
                CooldownTexts[index].text = "Ready";
            else
                CooldownTexts[index].text = $"{Mathf.Ceil(TimeLeftOnCooldown[index])} sec{(TimeLeftOnCooldown[index] >= 1f ? "s" : "")}";
        }
    }

    /// <summary>
    /// Time before the player can use another ability (so he cant spam the 4 abilities at once)
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator AttackChainingInterval(float delay)
    {
        Manager.player.IsAttacking = true;
        yield return new WaitForSeconds(delay);
        Manager.player.IsAttacking = false;
    }

}
