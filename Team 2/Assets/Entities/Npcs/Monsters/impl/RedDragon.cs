using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A red dragon npc
/// </summary>
public class RedDragon : Monster
{

    private GameObject npcPrefab;

    #region Constructors

    public RedDragon(int spawnId)
    {
        Id = MonsterInformation.Monsters.RED_DRAGON;
        InstanceId = spawnId;
        level = 1;
        displayName = "Blue Dragon";
        maxHp = level * MonsterInformation.HPRate;
        currentHp = maxHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonsterPrefabIds.RED_DRAGON];
    }

    public RedDragon(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        Id = MonsterInformation.Monsters.RED_DRAGON;
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        npcPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonsterPrefabIds.RED_DRAGON];
    }

    #endregion

    #region Interactions

    /// <summary>
    /// Spawn
    /// </summary>
    public override void Spawn(Position pos)
    {
        if (!isSpawned)
        {
            WorldPosition = pos;
            WorldModel = Object.Instantiate(npcPrefab);
            WorldModel.name = $"Monster,{InstanceId}";
            NPCAnimator = WorldModel.GetComponent<Animator>();
            WorldModel.transform.position = new Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
        }
        base.Spawn(pos);
    }

    /// <summary>
    /// Block
    /// </summary>
    public override void Block ()
    {
        if (!isDead)
        {
            isBlocking = true;
            NPCAnimator.SetTrigger("Block");
        }
    }

    /// <summary>
    /// Death
    /// </summary>
    public override void Death()
    {
        if (!isDead)
        {
            NPCAnimator.SetTrigger("Death");
            Debug.Log("Red Dragon is dead.");
            base.Death();
        }
    }

    /// <summary>
    /// Attack another entity
    /// </summary>
    /// <param name="toAttack"></param>
    public override void Attack(Entity toAttack)
    {
        isAttacking = true;
        NPCAnimator.SetTrigger("Attack");
        base.Attack(toAttack);
    }

    #endregion

}
