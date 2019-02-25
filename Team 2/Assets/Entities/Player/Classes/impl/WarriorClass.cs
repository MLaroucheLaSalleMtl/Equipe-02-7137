using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 21 FEB 19
/// @description The warrior class (close combat)
/// </summary>
public class WarriorClass : PlayerClass
{

    //the invisible trigger to know if the spells/attacks hit
    private GameObject hitbox;

    public override double Range { get; set; }
    public override bool IsMelee { get; set; }
    public override Dictionary<int, Spell> Spells { get; set; }
    public override string DisplayName { get; set; }
    public override string Description { get; set; }
    public override List<Skill> UnlockedSkills { get; set; }
    public override ClassesInformation.ClassesId Id { get; set; }

    public WarriorClass (GameObject hitboxObject)
    {
        Range = 2;
        IsMelee = true;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Warrior";
        Id = ClassesInformation.ClassesId.WARRIOR;
        Description = "A close combat class which is tankier than others.";
        UnlockedSkills = new List<Skill>();
        hitbox = hitboxObject;
        hitbox.transform.parent = GameObject.Find("Player").transform;
        hitbox.transform.position = new Vector3(hitbox.transform.position.x, hitbox.transform.position.y, hitbox.transform.position.z + 1);
    }

    /// <summary>
    /// Gets the damage of the basic attack
    /// </summary>
    /// <returns></returns>
    public int GetBasicAttackDamage(int strength)
    {
        return 1;
    }

    /// <summary>
    /// Does a basic attack
    /// </summary>
    public void BasicAttack()
    {

    }
}
