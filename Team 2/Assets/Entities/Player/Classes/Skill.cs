using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Skill
{

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

    //modifyer in minus %
    private float cooldownReduction;

    public List<Skill> upStreamSkills;
    public List<Skill> downStreamSkills;

    public float DexterityModifyer { get => dexterityModifyer; set => dexterityModifyer = value; }
    public float HealtModifyer { get => healtModifyer; set => healtModifyer = value; }
    public float StrenghtModifyer { get => strenghtModifyer; set => strenghtModifyer = value; }
    public float InteligenceModifyer { get => inteligenceModifyer; set => inteligenceModifyer = value; }
    public float SpellDamageModifyer { get => spellDamageModifyer; set => spellDamageModifyer = value; }
    public float CooldownReduction { get => cooldownReduction; set => cooldownReduction = value; }


    //activate the skill
    public void Activate()
    {
        if(Activatable())
        isActive = true;
    }

    //return if the skill can be activated or not
    private bool Activatable()
    {
        if(downStreamSkills.Count>0)
        {
            foreach(Skill s in downStreamSkills)
            {
                if(s.isActive)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return true;
        }
    }

}

