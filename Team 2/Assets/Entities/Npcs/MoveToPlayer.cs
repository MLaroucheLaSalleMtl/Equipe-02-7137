using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Samuel Paquette
/// @date 7 MAR 2019
/// @description Move a nav mesh towards the player
/// </summary>
public class MoveToPlayer : MonoBehaviour
{

    Transform playerTransform;
    NavMeshAgent npc;
    float cooldown = 2f;
    Vector3 sourcePosition;
    NavMeshHit closestHit;
    GameManager manager;

// Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerTransform = GameObject.Find("Player").transform;
        sourcePosition = transform.position;
        if (NavMesh.SamplePosition(sourcePosition, out closestHit, 500, 1))
        {
            transform.position = closestHit.position;
            gameObject.AddComponent<NavMeshAgent>();
        }
        npc = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0f)
        {
            if (!manager.npcHandler.SpawnedNPCs[int.Parse(gameObject.name.Split(',')[1])].isDead)
            {
                if (Mathf.Abs(Vector3.Distance(transform.position, playerTransform.position)) >= 2.80f)
                {
                    npc.destination = playerTransform.position;
                }
                else
                {
                    npc.destination = transform.position;
                }
            }
            else
            {
                npc.destination = transform.position;
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
