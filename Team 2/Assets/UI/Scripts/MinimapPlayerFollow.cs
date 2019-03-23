using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 23 MARS 2019
/// @description Minimap camera follows the player position
/// </summary>
public class MinimapPlayerFollow : MonoBehaviour
{

    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.localPosition.x, transform.position.y, player.transform.localPosition.z);    
    }
}
