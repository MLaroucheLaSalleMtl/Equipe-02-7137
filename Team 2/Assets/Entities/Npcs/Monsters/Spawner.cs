﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameManager manager;
    [SerializeField] int spawnRange=10;
    [SerializeField] float playerRange = 50;
    [SerializeField] float minSpawnTime = 5;
    [SerializeField] float maxSpawnTime = 15;
    [SerializeField] Transform player;
    [SerializeField] MonsterInformation.Monsters[] type;
    [SerializeField] int maxMonsterCount = 12;
    List<Monster> myMonsters=new  List<Monster>();
    [SerializeField] bool respawnMonsters=true;

    // Start is called before the first frame update
    void Start()
    {
        //gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if(player=null)
        //{
        //    player = GameObject.Find("Player").GetComponent<Transform>();
        //}
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("Spawn", 5.0f);
    }


    void Spawn()
    {
        float time = Random.Range(minSpawnTime, maxSpawnTime);
        if (respawnMonsters) ResizeTable();
        if(Vector3.Distance(player.transform.position,transform.position)<playerRange&&myMonsters.Count<maxMonsterCount)
        {
            int monster = Random.Range(0, type.Length );
            int spawnX = Random.Range(-spawnRange, spawnRange);
            int spawnZ = Random.Range(-spawnRange, spawnRange);
            string name = type[monster].ToString().Substring(0, 1) + type[monster].ToString().Substring(1).ToLower().Replace('_', ' ');
            var spawnPos = new Position(spawnX + (int)transform.position.x, (int)transform.position.y, spawnZ + (int)transform.position.z);
            manager.monsterHandler.GetStatsForLevel(manager.player.Level, out int maxHp, out int attackDamage, MonsterInformation.monsterDificulties[type[monster]]);
            var newMonster = manager.monsterHandler.SpawnMonster(type[monster], spawnPos, name, manager.player.Level, maxHp, maxHp);
            manager.monsterHandler.SetStatsForLevel(manager.player.Level, newMonster, type[monster]);
            myMonsters.Add(newMonster);
        }
        Invoke("Spawn", time);
    }

    void ResizeTable()
    {
        for(int i=0;i<myMonsters.Count;i++)
        {
            if(myMonsters[i].isDead)
            {
                myMonsters.Remove(myMonsters[i]);
            }
        }
    }

}
