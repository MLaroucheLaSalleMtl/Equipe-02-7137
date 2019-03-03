using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangerClass : PlayerClass
{
    
    private bool isMelee;
    private Dictionary<int, Spell> spells;
    private string displayName;
    private string description;
    private int level;

    private double strengh;
    private double agility;
    private double intelligence;

   
    public override bool IsMelee { get => isMelee; set => isMelee = value; }
    public override Dictionary<int, Spell> Spells { get => spells; set => spells = value; }
    public override string DisplayName { get => displayName; set => displayName = value; }
    public override string Description { get => description; set => description = value; }
    public override int Level { get => level; set => level = value; }
    public override double Strengh { get => strengh; set => strengh = value; }
    public override double Agility { get => agility; set => agility = value; }
    public override double Intelligence { get => intelligence; set => intelligence = value; }
    public RangerClass()
    {
       
        IsMelee = false;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Ranger";
        Description = "The Ranger is an archer type class who uses bows as its weapon and agility as its main stat";
        Level = 1;
        Agility = 3;
        Strengh = 1;
        Intelligence = 1;
    }
    public override void Levelup()
    {
        level++;
        Intelligence++;
        Agility++;
        Agility++;
        Strengh++;
    }
}
