using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 1 February 2019
/// @description A position in the world
/// </summary>
public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Position ()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public Position (int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
