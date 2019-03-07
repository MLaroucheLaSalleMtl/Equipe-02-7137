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
    
    private GameManager manager;
    private double strengh;
    private double agility;
    private double intelligence;
    private int level;

    public override double Range { get; set; }
    public override bool IsMelee { get; set; }
    public override Dictionary<int, Spell> Spells { get; set; }
    public override string DisplayName { get; set; }
    public override string Description { get; set; }
    public override List<Skill> UnlockedSkills { get; set; }
    public override ClassesInformation.ClassesId Id { get; set; }
    public override double Strengh { get => strengh; set => strengh = value; }
    public override double Agility { get => agility; set => agility = value; }
    public override double Intelligence { get => intelligence; set => intelligence = value; }
    public override int Level { get => level; set => level = value; }

    public override void Levelup()
    {
        //XPY = 0;
        //XPX += 500;
        //SkillTreeUnlock += 1;
        level++;
        Intelligence++;
        Agility++;
        Strengh++;
        Strengh++;
    }

    public WarriorClass ()
    {
        Range = 3.5;
        IsMelee = true;
        Spells = new Dictionary<int, Spell>();
        DisplayName = "Warrior";
        Id = ClassesInformation.ClassesId.WARRIOR;
        Description = "A close combat class which is tankier than others.";
        UnlockedSkills = new List<Skill>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Level = 1;
        Agility = 1;
        Strengh = 3;
        Intelligence = 1;
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
    public void BasicAttack(NPC[] npcsToAttack)
    {
        if (npcsToAttack.Length > 0)
        {
            for (int index = 0; index < npcsToAttack.Length; index++)
            {
                manager.npcHandler.RemoveHp(npcsToAttack[index], GetBasicAttackDamage(1));
            }
        }
        manager.combatHandler.attacksAnimator[(int)ClassesInformation.ClassesId.WARRIOR].SetTrigger("BasicAttack");
    }

    /// <summary>
    /// E swing with axe
    /// </summary>
    /// <param name="npcsToAttack"></param>
    public void SwingAttack(NPC[] npcsToAttack)
    {
        if (npcsToAttack.Length > 0)
        {
            for (int index = 0; index < npcsToAttack.Length; index++)
            {
                manager.npcHandler.RemoveHp(npcsToAttack[index], GetBasicAttackDamage(1));
            }
        }
        manager.combatHandler.attacksAnimator[(int)ClassesInformation.ClassesId.WARRIOR].SetTrigger("SwingAttack");
    }

    /// <summary>
    /// Jump attack
    /// </summary>
    /// <param name="npcsToAttack"></param>
    public void JumpAttack(NPC[] npcsToAttack)
    {
        if (npcsToAttack.Length > 0)
        {
            for (int index = 0; index < npcsToAttack.Length; index++)
            {
                manager.npcHandler.RemoveHp(npcsToAttack[index], GetBasicAttackDamage(1));
            }
        }
        manager.combatHandler.attacksAnimator[(int)ClassesInformation.ClassesId.WARRIOR].SetTrigger("JumpAttack");
    }

    /// <summary>
    /// Double swing attack
    /// </summary>
    /// <param name="npcsToAttack"></param>
    public void DoubleSwingAttack(NPC[] npcsToAttack)
    {
        if (npcsToAttack.Length > 0)
        {
            for (int index = 0; index < npcsToAttack.Length; index++)
            {
                manager.npcHandler.RemoveHp(npcsToAttack[index], GetBasicAttackDamage(2));
            }
        }
        manager.combatHandler.attacksAnimator[(int)ClassesInformation.ClassesId.WARRIOR].SetTrigger("DoubleSwingAttack");
    }
}
