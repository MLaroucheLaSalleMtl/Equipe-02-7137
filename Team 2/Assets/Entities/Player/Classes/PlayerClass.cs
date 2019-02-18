using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 12 FEB 19
/// @description The abstract design of the class of the player
/// </summary>
public abstract class PlayerClass
{

    public abstract double Range { get; set; }
    public abstract bool IsMelee { get; set; }
    public abstract Dictionary<int, Spell> Spells { get; set; }
    public abstract string DisplayName { get; set; }
    public abstract string Description { get; set; }
    public abstract List<Skill> Skills { get; set; }

}
