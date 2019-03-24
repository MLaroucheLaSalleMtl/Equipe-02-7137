using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 24 MARS 2019
/// @description A dialogue with the head of a npc, character, etc at the left of the dialogue
/// </summary>
public class HeadDialogue : Dialogue
{
    
    public Sprite Head { get; set; }

    public HeadDialogue (string name, string text, Sprite head) : base(name, text)
    {
        Head = head;
    }

}
