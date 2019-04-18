using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 17 AVR 2019
/// @description The Wiezzorek npc
/// </summary>
public class Wiezzorek : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.WIEZZOREK;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        
    }

}
