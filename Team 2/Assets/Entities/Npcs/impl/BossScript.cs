using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject Zombie;
    private Vector3 destination;
    private NavMeshAgent agent;
    private Animator ZombieAnim;
    [SerializeField] private float ActivityRange = 30;
    [SerializeField] private float Distance;    
    private RaycastHit Cast;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                ZombieAnim.SetTrigger("InAttackRange");
        }

    }
    void Start()
    {
        ZombieAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        Distance = Cast.distance;
        if (Distance < ActivityRange)
        {
            transform.LookAt(target.transform);
            ZombieAnim.SetTrigger("InRange");

        }

        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
        
    }

}
