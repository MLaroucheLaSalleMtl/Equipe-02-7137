using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 13 February 2019
/// @description Handles everything related to the items
/// </summary>
public class ItemHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Picks up an item and add it to the inventory of the player
    /// </summary>
    public void PickUp(ItemData item)
    {

    }

}
