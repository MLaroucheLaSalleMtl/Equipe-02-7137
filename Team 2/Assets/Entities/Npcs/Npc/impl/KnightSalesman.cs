using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 18 AVR 2019
/// @description The Knight Salesman npc
/// </summary>
public class KnightSalesman : NPC
{

    GameManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Id = NPCInformation.NPCIds.KNIGHT_SALESMAN;
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        if (!manager.shopHandler.IsShopping)
        {
            manager.shopHandler.OpenShop();
            manager.playerHandler.UpdatePlayerBarUI();
        }
    }

}
