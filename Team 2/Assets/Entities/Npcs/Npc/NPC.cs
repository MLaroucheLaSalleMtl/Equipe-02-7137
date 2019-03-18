using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 17 MARS 2019
/// @description A npc that we can interact with in the world
/// </summary>
public class NPC : Interactable
{

    Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Interact with a npc
    /// </summary>
    /// <param name="player"></param>
    public override void ExecuteAction(Player player)
    {
        Debug.Log("Talk to npc");
        animator.SetTrigger("Dance");   
    }

}
