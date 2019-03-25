using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        //gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if(player=null)
        //{
        //    player = GameObject.Find("Player").GetComponent<Transform>();
        //}
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float time = Random.Range(minSpawnTime, maxSpawnTime);
        if(Vector3.Distance(player.transform.position,transform.position)<playerRange)
        {
            int monster = Random.Range(0, type.Length - 1);
            int spawnX = Random.Range(-spawnRange, spawnRange);
            int spawnZ = Random.Range(-spawnRange, spawnRange);
            manager.monsterHandler.SpawnMonster(type[monster], new Position(spawnX+ (int)transform.position.x, (int)transform.position.y, spawnZ+ (int)transform.position.z), type[monster].ToString(), 1, 5, 5);
        }
        Invoke("Spawn", time);
    }

}
