using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentControler : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] float range;
    [SerializeField] GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closest=null;
        float distance=float.MaxValue;

        foreach(GameObject g in targets)
        {
            float d = Vector3.Distance(transform.position, g.transform.position);
            if (d<range&&d<distance)
            {
                distance = d;
                closest = g;
            }
        }
        if(closest!=null)
        agent.SetDestination(closest.transform.position);
    }
}
