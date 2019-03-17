using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 February 2019
/// @description A simple Skeleton NPC
/// </summary>
public class Skeleton : NPC
{

    private GameObject prefab;

    #region Constructors

    public Skeleton (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Skeleton";
        maxHp = level * NPCInformation.HPRate;
        currentHp = maxHp;
        prefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.SKELETON];
    }

    public Skeleton(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        prefab = GameObject.Find("GameManager").GetComponent<NPCHandler>().npcPrefabs[(int)NPCInformation.NPCPrefabId.SKELETON];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn a this npc
    /// </summary>
    public override void Spawn(Position pos)
    {
        if (!isSpawned)
        {
            WorldPosition = pos;
            WorldModel = Object.Instantiate(prefab);
            WorldModel.name = $"Monster,{InstanceId}";
            NPCAnimator = WorldModel.GetComponent<Animator>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Block animation
    /// </summary>
    public override void Block()
    {
        if (!isBlocking && !isDead && !isAttacking)
        {
            isBlocking = true;
            NPCAnimator.SetTrigger("Action");
        }
        NPCAnimator.SetFloat("State", (float)NPCInformation.NPCStateInfo.BLOCK);
    }

    /// <summary>
    /// Death
    /// </summary>
    public override void Death()
    {
        if (!isBlocking && !isDead && !isAttacking)
        {
            NPCAnimator.SetTrigger("Action");
        }
        NPCAnimator.SetFloat("State", (float)NPCInformation.NPCStateInfo.DEATH);
        base.Death();
    }

    /// <summary>
    /// Attack another entity
    /// </summary>
    /// <param name="toAttack"></param>
    public override void Attack(Entity toAttack)
    {
        if (!isBlocking && !isDead && !isAttacking)
        {
            isAttacking = true;
            NPCAnimator.SetTrigger("Action");
        }
        NPCAnimator.SetFloat("State", (float)NPCInformation.NPCStateInfo.ATTACK);
        base.Attack(toAttack);
    }

    #endregion

}
