using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject moveTarget;
    [SerializeField] GameObject projectile;

    private NavMeshAgent agent;
    private Vector3 destination;
    //tags for object clicked on: 0 = ground for movement, 1 = monster to attack, 2 = item to pick up

    const string ground = "Ground";
    const string monster = "Monster";
    const string item = "Item";

    Collider monsterTarget;

    [SerializeField] float attackRange = 1;



    // Start is called before the first frame update
    void Start()
    {
        moveTarget.transform.position = transform.position;
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
            switch (hit.collider.gameObject.tag)
            {
                case ground:
                    Move(hit);
                    break;

                case monster:
                    Attack(hit.collider);
                    break;
            }
        }
        //if(monsterTarget!=null)
        //{
        //    if (Vector3.Distance(monsterTarget.transform.position, transform.position) <= attackRange)
        //    {
        //        moveTarget.transform.position = transform.position;
        //        Attack(monsterTarget);
        //    }
        //    else
        //    {
        //        Move(monsterTarget);
        //    }
        //}
    }
    public void Move(RaycastHit hit)
    {
        moveTarget.transform.position = hit.point;
        destination = moveTarget.transform.position;
        agent.destination = destination;
    }
    public void Move(Collider monster)
    {
        moveTarget.transform.position = transform.position;
        destination = moveTarget.transform.position;
        agent.destination = destination;
    }
    public void Move(Transform pTransform)
    {
        moveTarget.transform.position = pTransform.position;
        destination = moveTarget.transform.position;
        agent.destination = destination;
    }

    void Attack(Collider monster)
    {
        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        switch (manager.player.Class.Id)
        {
            case ClassesInformation.ClassesId.WARRIOR:
                if (manager.combatHandler.CanAttack(manager.npcHandler.SpawnedNPCs[0]))
                {
                    manager.combatHandler.Attack(manager.npcHandler.SpawnedNPCs[0]);
                }
                else
                {
                    Move(monster.gameObject.transform);
                }
                break;
        }
        //GameObject p = Instantiate(projectile,transform);
        //var ptarget = p.GetComponent<ProjectileTarget>();
        //ptarget.target = monster.gameObject.transform;
        //ptarget.owner = this.transform;
        //p.transform.parent = null;
    }
}
