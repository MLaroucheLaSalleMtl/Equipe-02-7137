using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The warrior class (close combat)
/// </summary>
public abstract class WarriorClass : PlayerClass
{


    public WarriorClass ()
    {
        Range = 2;
        IsMelee = true;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Warrior";
        Description = "A close combat class which is tankier than others.";
        UnlockedSkills = new List<Skill>();
    }

}
