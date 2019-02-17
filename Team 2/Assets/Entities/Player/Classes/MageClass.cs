using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MageClass : PlayerClass
{
    private double range;
    private bool isMelee;
    private Dictionary<int, Spell> spells;
    private string displayName;
    private string description;



    public override double Range { get => range; set => range = value; }
    public override bool IsMelee { get => isMelee;  set => isMelee = value; }
    public override Dictionary<int, Spell> Spells { get => spells;  set => spells = value; }
    public override string DisplayName { get => displayName;  set => displayName = value; }
    public override string Description { get => description;  set => description = value; }
    public override List<Skill> Skills { get => Skills; set => Skills = value; }

    public MageClass()
    {
        Range = 5;
        IsMelee = false;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Mage";
        Description = "A range classe whit intelligence as main stat";
    }
}

