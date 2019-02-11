using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description Handles everything related to npcs
/// </summary>
public class NPCHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager manager;

    /// <summary>
    /// Called at the start of the game
    /// </summary>
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        
    }
}
