using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A simple gold boar NPC
/// </summary>
public class GoldBoar : Monster
{

    private GameObject goldBoarPrefab;

    #region Constructors

    public GoldBoar(int spawnId)
    {
        Id = MonsterInformation.Monsters.GOLD_BOAR;
        InstanceId = spawnId;
        level = 1;
        displayName = "Gold Boar";
        maxHp = level * MonsterInformation.HPRate;
        currentHp = maxHp;
        goldBoarPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonsterPrefabIds.GOLD_BOAR];
    }

    public GoldBoar(int spawnId, string name, int level, int maxHp, int currentHp)
    {
        Id = MonsterInformation.Monsters.GOLD_BOAR;
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        goldBoarPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonsterPrefabIds.GOLD_BOAR];
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
            WorldModel = Object.Instantiate(goldBoarPrefab);
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
            Debug.Log("Gold boar is dead.");
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
