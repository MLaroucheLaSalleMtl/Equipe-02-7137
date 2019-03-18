using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 Mars 2019
/// @description A simple blue boar NPC
/// </summary>
public class BlueBoar : Monster
{

    private GameObject blueboarPrefab;

    #region Constructors

    public BlueBoar (int spawnId)
    {
        InstanceId = spawnId;
        level = 1;
        displayName = "Blue Boar";
        maxHp = level * MonsterInformation.HPRate;
        currentHp = maxHp;
        blueboarPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonstersPrefabId.BLUE_BOAR];
    }

    public BlueBoar (int spawnId, string name, int level, int maxHp, int currentHp)
    {
        InstanceId = spawnId;
        this.level = level;
        displayName = name;
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        blueboarPrefab = GameObject.Find("GameManager").GetComponent<MonsterHandler>().monsterPrefabs[(int)MonsterInformation.MonstersPrefabId.BLUE_BOAR];
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
            WorldModel = Object.Instantiate(blueboarPrefab);
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
            Debug.Log("Blue boar is dead.");
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
