using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MageClass : PlayerClass
{
    private Dictionary<int, Spell> spells;
    private string displayName;
    private string description;
    private int level;
    private double strengh;
    private double agility;
    private double intelligence;
    private bool isMelee;
    public override bool IsMelee { get => isMelee; set => isMelee = value; }
    public override Dictionary<int, Spell> Spells { get => spells; set => spells = value; }
    public override string DisplayName { get => displayName; set => displayName = value; }
    public override string Description { get => description; set => description = value; }
    public override int Level { get => level; set => level = value; }
    public override double Strengh { get => strengh; set => strengh = value; }
    public override double Agility { get => agility; set => agility = value; }
    public override double Intelligence { get => intelligence; set => intelligence = value; }
    public MageClass()
    {
   
        IsMelee = false;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Mage";
        Description = "A ranged class with intelligence as main stat";
        Level = 1;
        Agility = 1;
        Strengh = 1;
        Intelligence = 3;
    }

    public override void Levelup()
    {
        level++;
        Intelligence++;
        Intelligence++;
        Agility++;
        Strengh++;
    }
}
