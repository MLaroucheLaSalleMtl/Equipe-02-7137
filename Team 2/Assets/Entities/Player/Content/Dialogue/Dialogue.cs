using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 24 MARS 2019
/// @description A dialogue
/// </summary>
public class Dialogue
{
    
    public string Name { get; set; }
    public string Text { get; set; }

    public Dialogue (string name, string text)
    {
        Name = name;
        Text = text;
    }

}
