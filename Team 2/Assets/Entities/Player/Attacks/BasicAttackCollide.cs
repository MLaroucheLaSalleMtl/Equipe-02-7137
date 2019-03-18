
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackCollide : MonoBehaviour
{
    GameManager manager;

    void Start ()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Monster")
        {
            Monster npc = manager.monsterHandler.SpawnedMonsters[int.Parse(collider.gameObject.name.Split(',')[1])];
            if (!manager.combatHandler.NpcsCurrentlyInHitbox.Contains(npc))
            {
                manager.combatHandler.NpcsCurrentlyInHitbox.Add(npc);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Monster")
        {
            Monster npc = manager.monsterHandler.SpawnedMonsters[int.Parse(collider.gameObject.name.Split(',')[1])];
            if (manager.combatHandler.NpcsCurrentlyInHitbox.Contains(npc))
            {
                manager.combatHandler.NpcsCurrentlyInHitbox.Remove(npc);
            }
        }
    }
}
