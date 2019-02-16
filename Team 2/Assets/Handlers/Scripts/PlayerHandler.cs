using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 12 February 2019
/// @description Handles everything related to the player
/// </summary>
public class PlayerHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Called at the start of the game
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        
    }
}
