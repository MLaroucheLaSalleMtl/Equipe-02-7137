﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField] float speed=2;
    public Transform owner;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        Vector3 direction =target.transform.position- transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Monster")
        {
            Debug.Log("Collide");
            //monster loses hp
            int spawnId = int.Parse(other.gameObject.name.Split(',')[1]);
            if (manager.npcHandler.SpawnedNPCs.ContainsKey(spawnId))
            {
                NPC monster = manager.npcHandler.SpawnedNPCs[spawnId];
                if ((monster.CurrentHp - 1) <= 0)
                {
                    manager.npcHandler.HandleDeath(monster);
                }
                else
                {
                    monster.RemoveHp(1);
                }
                
            }
        }
        Destroy(gameObject);
    }

}
