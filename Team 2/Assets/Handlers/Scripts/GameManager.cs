﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description The bi-directional link between all the handlers needed for the gameplay of the player
/// </summary>
public class GameManager : MonoBehaviour
{
    NPCHandler NpcHandler { get; set; }

    /// <summary>
    /// Called when the game is launched
    /// </summary>
    void Start()
    {
        NpcHandler = GetComponent<NPCHandler>();
        
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {

    }
}
