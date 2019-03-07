using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    void Attack(Collider monster)
    {
        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        switch (manager.player.Class.Id)
        {
            case ClassesInformation.ClassesId.WARRIOR:
                int npcInstanceId = int.Parse(monster.gameObject.name.Split(',')[1]);
                NPC npcToAttack = manager.npcHandler.SpawnedNPCs[npcInstanceId];
                if (manager.combatHandler.CanAttack(npcToAttack))
                {
                   // manager.combatHandler.Attack(npcToAttack);
                }
                else
                {
                }
                break;
        }
    }
}
