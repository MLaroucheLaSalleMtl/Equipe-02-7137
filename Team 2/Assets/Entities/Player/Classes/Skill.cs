using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Skill
{
    SkillTree parent;
    public string name;
    public string description;
    public bool isActive;
    public Vector2Int treePos;

    //modifyer in additional %
    private float dexterityModifyer;
    private float healtModifyer;
    private float strenghtModifyer;
    private float inteligenceModifyer;
    private float spellDamageModifyer;
    private float rangeModifyer;
    private float defModifyer;
    private float speedModifyer;

    //modifyer in minus %
    private float cooldownReduction;

    public List<Skill> upStreamSkills;
    public List<Skill> downStreamSkills;
    public SkillTree Parent { get => parent; set => parent = value; }

    public Skill(SkillTree parent, float dexMod=0, float healtMod=0, float strenghtMod=0, float intelMod=0, float spellDmgMod=0, float rangeMod=0, float defMod=0, float speedMod=0, float cdRed=0)
    {
        upStreamSkills = new List<Skill>();
        downStreamSkills = new List<Skill>();
        Parent = parent;
        dexterityModifyer = dexMod;
        healtModifyer = healtMod;
        strenghtModifyer = strenghtMod;
        inteligenceModifyer = intelMod;
        spellDamageModifyer = spellDmgMod;
        rangeModifyer = rangeMod;
        defModifyer = defMod;
        speedModifyer = speedMod;
        cooldownReduction = cdRed;
    }

    public float DexterityModifyer { get => dexterityModifyer; set => dexterityModifyer = value; }
    public float HealtModifyer { get => healtModifyer; set => healtModifyer = value; }
    public float StrenghtModifyer { get => strenghtModifyer; set => strenghtModifyer = value; }
    public float InteligenceModifyer { get => inteligenceModifyer; set => inteligenceModifyer = value; }
    public float SpellDamageModifyer { get => spellDamageModifyer; set => spellDamageModifyer = value; }
    public float CooldownReduction { get => cooldownReduction; set => cooldownReduction = value; }
    public float RangeModifyer { get => rangeModifyer; set => rangeModifyer = value; }
    public float DefModifyer { get => defModifyer; set => defModifyer = value; }
    public float SpeedModifyer { get => speedModifyer; set => speedModifyer = value; }


    //activate the skill
    public bool Activate()
    {
        bool activatable = Activatable();
        if (activatable)
        {
            isActive = true;
            Parent.Activated++;
            parent.Manager.player.Class.UnlockedSkills.Add(this);
            parent.Manager.playerHandler.HealPlayer((int)(parent.Manager.player.MaxHP * healtModifyer / 100));
        }
        return activatable;
    }

    //return if the skill can be activated or not
    private bool Activatable()
    {
        bool activatable = false;
        if (parent.Manager.player.Level > parent.Activated)
        {

            if (downStreamSkills.Count > 0)
            {
                foreach (Skill s in downStreamSkills)
                {
                    if (s.isActive)
                    {
                        activatable= true;
                    }
                }
            }
            else
            {
                activatable = true;
            }
        }
        return activatable;
    }

    public void Deactivate()
    {
        parent.Manager.playerHandler.DamagePlayer((int)(parent.Manager.player.MaxHP * healtModifyer / 100));
    }

}

