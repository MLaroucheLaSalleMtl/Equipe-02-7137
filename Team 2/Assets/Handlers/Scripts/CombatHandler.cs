using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<NPC> NpcsCurrentlyInHitbox { get; set; }

    //hitboxes for the classes
    public Animator[] attacksAnimator;

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Checks if we can attack the npc passed in parameters
    /// </summary>
    /// <param name="npcToAttack"></param>
    /// <returns></returns>
    public bool CanAttack (NPC npcToAttack)
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
        if (keyIndex == -1)
        {
            return;
        }
        switch (Manager.player.Class.Id)
        {
            case ClassesInformation.ClassesId.WARRIOR:
                WarriorClass playerClass = Manager.player.Class as WarriorClass;
                switch (keyIndex)
                {
                    case (int)ClassesInformation.WarriorKeyIndex.BASIC_ATTACK:
                        CurrentHitbox = GameObject.Find("BasicAttackHitbox");
                        playerClass.BasicAttack(NpcsCurrentlyInHitbox.ToArray());
                        break;
                    case (int)ClassesInformation.WarriorKeyIndex.SWING_ATTACK:
                        CurrentHitbox = GameObject.Find("BasicAttackHitbox");
                        playerClass.SwingAttack(NpcsCurrentlyInHitbox.ToArray());
                        break;
                    case (int)ClassesInformation.WarriorKeyIndex.JUMP_ATTACK:
                        CurrentHitbox = GameObject.Find("BasicAttackHitbox");
                        playerClass.JumpAttack(NpcsCurrentlyInHitbox.ToArray());
                        break;
                    case (int)ClassesInformation.WarriorKeyIndex.DOUBLE_SWING_ATTACK:
                        CurrentHitbox = GameObject.Find("BasicAttackHitbox");
                        playerClass.DoubleSwingAttack(NpcsCurrentlyInHitbox.ToArray());
                        break;
                }
                break;
        }
    }


    /// <summary>
    /// Called at the start of the game
    /// </summary>
    void Start()
    {
        NpcsCurrentlyInHitbox = new List<NPC>();
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        
    }
}
