using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerClass : PlayerClass
{
    private double range;
    private bool isMelee;
    private Dictionary<int, Spell> spells;
    private string displayName;
    private string description;

    public override double Range { get => range; set => range = value; }
    public override bool IsMelee { get => isMelee; set => isMelee = value; }
    public override Dictionary<int, Spell> Spells { get => spells; set => spells = value; }
    public override string DisplayName { get => displayName; set => displayName = value; }
    public override string Description { get => description; set => description = value; }
    public override List<Skill> UnlockedSkills { get; set; }

    public RangerClass()
    {
        Range = 10;
        IsMelee = false;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Ranger";
        Description = "The Ranger is an archer type class who uses bows as its weapon and agility as its main stat";
    }

}

