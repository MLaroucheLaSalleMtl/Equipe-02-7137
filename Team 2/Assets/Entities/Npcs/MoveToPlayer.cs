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

    //the transform of the player it is moving to
    Transform playerTransform;

    //the nav mesh agent of the npc
    NavMeshAgent npc;

    //cooldown before the npc starting moving towards the player after being spawned
    float cooldown = 2f;

    //how much we are smoothing the animations (walking, etc.)
    float animationSmoothing = 0.1f;

    //the original position of the npc to get the closest nav mesh
    Vector3 sourcePosition;

    //hit of the closest navmesh found
    NavMeshHit closestHit;

    //our game manager to handle everything
    GameManager manager;

    //the actual npc that we are moving
    NPC movingNpc;

    //the animator of the npc
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //get the manager
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //get the animator
        animator = GetComponent<Animator>();

        //get the transform of the player
        playerTransform = GameObject.Find("Player").transform;

        //our original position
        sourcePosition = transform.position;

        //get the closest navmesh
        if (NavMesh.SamplePosition(sourcePosition, out closestHit, 500, 1))
        {
            transform.position = closestHit.position;
            gameObject.AddComponent<NavMeshAgent>();
        }

        //get the navmesh of the npc
        npc = GetComponent<NavMeshAgent>();

        //get the actual npc
        movingNpc = manager.npcHandler.SpawnedNPCs[int.Parse(gameObject.name.Split(',')[1])];
    }

    // Update is called once per frame
    void Update()
    {
        //if the cooldown is 0, means the npc can start moving
        if (cooldown <= 0f)
        {
            //if the npc is dead, is blocking or is attacking, npc wont move
            if (!movingNpc.isDead && !movingNpc.isBlocking && !movingNpc.isAttacking)
            {
                //check the distance between the player and the npc, if its less or equal to 2.8, it stops moving
                if (Mathf.Abs(Vector3.Distance(transform.position, playerTransform.position)) >= 2.80f)
                {
                    npc.destination = playerTransform.position;
                }
                else
                {
                    //if the cooldown of the npc attacking is 0, then npc attacks
                    if (movingNpc.CooldownLeft <= 0f)
                    {
                        manager.npcHandler.HandleAttack(movingNpc);
                        movingNpc.CooldownLeft = movingNpc.AttackCooldown;
                    }
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

        //Decreasing cooldown of npc attack
        movingNpc.CooldownLeft -= Time.deltaTime;
        if (movingNpc.CooldownLeft <= 0f)
        {
            movingNpc.CooldownLeft = 0f;
        }

        //Apply root motion (animations for the walking of the npc)
        float speed = npc.velocity.magnitude / npc.speed;
        animator.SetFloat("Speed", speed, animationSmoothing, Time.deltaTime);
    }
}
