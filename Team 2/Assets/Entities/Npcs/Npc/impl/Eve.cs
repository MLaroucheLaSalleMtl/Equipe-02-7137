using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 17 AVR 2019
/// @description The Eve npc
/// </summary>
public class Eve : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.EVE;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        
    }

}
