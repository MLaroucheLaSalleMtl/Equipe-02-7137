using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 February 2019
/// @description A simple Skeleton NPC
/// </summary>
public class Skeleton : Monster
{

    private GameObject prefab;

    #region Constructors

    public Skeleton (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Skeleton";
        maxHp = level * MonsterInformation.HPRate;
        currentHp = maxHp;
        prefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonstersPrefabId.SKELETON];
    }

    public Skeleton(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        prefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonstersPrefabId.SKELETON];
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
        ExecuteActionState(MonsterInformation.MonstersStateInfo.BLOCK);
        isBlocking = true;
    }

    /// <summary>
    /// Death
    /// </summary>
    public override void Death()
    {
        ExecuteActionState(MonsterInformation.MonstersStateInfo.DEATH);
        base.Death();
    }

    /// <summary>
    /// Attack another entity
    /// </summary>
    /// <param name="toAttack"></param>
    public override void Attack(Entity toAttack)
    {
        ExecuteActionState(MonsterInformation.MonstersStateInfo.ATTACK);
        isAttacking = true;
        base.Attack(toAttack);
    }

    #endregion

}
