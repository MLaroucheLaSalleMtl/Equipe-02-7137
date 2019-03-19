using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 11 MARS 2019
/// @description Makes a UI item billboard (always look at camera)
/// </summary>
public class Billboard : MonoBehaviour
{
    //Makes the UI item looks at camera each frame incase the player moves, etc.
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
