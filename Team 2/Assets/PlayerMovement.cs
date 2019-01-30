using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject target;

    private NavMeshAgent agent;
    private Vector3 destination;



    // Start is called before the first frame update
    void Start()
    {
        target.transform.position = transform.position;
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Move"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            target.transform.position = hit.point;
            destination = target.transform.position;
            agent.destination = destination;


        }

    }
   
}
