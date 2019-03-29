using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SkillTree
{
    GameManager manager;
    int activated = 0;
    Dictionary<string, Skill> skills;
    const int HIGHT = 5;
    const int WIDTH = 5;

    public int Activated { get => activated; set => activated = value; }
    public GameManager Manager { get => manager; set => manager = value; }
    public Dictionary<string, Skill> Skills { get => skills; set => skills = value; }

    public SkillTree(GameManager manager)
    {
        Manager = manager;
        skills = new Dictionary<string, Skill>()
        {
            { "hp1" ,new Skill(this,healtMod: 10) },
            { "hp2" ,new Skill(this,healtMod: 10) },
            { "hp3" ,new Skill(this,healtMod: 20) },
            { "def1" ,new Skill(this,defMod: 10) },
            { "def2" ,new Skill(this,defMod: 10) },
            { "def3" ,new Skill(this,defMod: 20) },

            { "dex1" ,new Skill(this,dexMod: 10) },
            { "dex2" ,new Skill(this,dexMod: 10) },
            { "dex3" ,new Skill(this,dexMod: 10) },
            { "range1" ,new Skill(this,rangeMod: 10) },
            { "range2" ,new Skill(this,rangeMod: 10) },
            { "CD1" ,new Skill(this,cdRed: 10) },
            { "CD2" ,new Skill(this,cdRed: 10) },
            { "dexUlt" ,new Skill(this,cdRed: 20,dexMod: 20) },

            { "str1" ,new Skill(this,strenghtMod: 10) },
            { "str2" ,new Skill(this,strenghtMod: 10) },
            { "str3" ,new Skill(this,strenghtMod: 10) },
            { "mvt1" ,new Skill(this,speedMod: 10) },
            { "mvt2" ,new Skill(this,speedMod: 10) },
            { "dmg1" ,new Skill(this,spellDmgMod: 10) },
            { "dmg2" ,new Skill(this,spellDmgMod: 10) },
            { "strUlt" ,new Skill(this,spellDmgMod: 20,strenghtMod: 20) },

            { "int1" ,new Skill(this,intelMod: 10) },
            { "int2" ,new Skill(this,intelMod: 10) },
            { "int3" ,new Skill(this,intelMod: 10) },
            { "dmg3" ,new Skill(this,spellDmgMod: 10) },
            { "dmg4" ,new Skill(this,spellDmgMod: 10) },
            { "CD3" ,new Skill(this,cdRed: 10) },
            { "CD4" ,new Skill(this,cdRed: 10) },
            { "intUlt" ,new Skill(this,spellDmgMod: 20,cdRed: 20) },
        };

        LinkSkills(skills["hp1"], skills["def1"]);
        LinkSkills(skills["def1"], skills["hp2"]);
        LinkSkills(skills["def1"], skills["def2"]);
        LinkSkills(skills["def2"], skills["def3"]);
        LinkSkills(skills["hp2"], skills["hp3"]);

        LinkSkills(skills["dex1"], skills["range1"]);
        LinkSkills(skills["range1"], skills["CD1"]);
        LinkSkills(skills["range1"], skills["dex2"]);
        LinkSkills(skills["dex2"], skills["range2"]);
        LinkSkills(skills["CD1"], skills["dexUlt"]);
        LinkSkills(skills["CD1"], skills["CD2"]);
        LinkSkills(skills["CD2"], skills["dex3"]);

        LinkSkills(skills["str1"], skills["mvt1"]);
        LinkSkills(skills["mvt1"], skills["dmg2"]);
        LinkSkills(skills["mvt1"], skills["str2"]);
        LinkSkills(skills["str2"], skills["mvt2"]);
        LinkSkills(skills["dmg1"], skills["strUlt"]);
        LinkSkills(skills["dmg1"], skills["dmg2"]);
        LinkSkills(skills["dmg2"], skills["str3"]);

        LinkSkills(skills["int1"], skills["int2"]);
        LinkSkills(skills["int2"], skills["dmg3"]);
        LinkSkills(skills["int2"], skills["CD3"]);
        LinkSkills(skills["int2"], skills["int3"]);
        LinkSkills(skills["dmg3"], skills["dmg4"]);
        LinkSkills(skills["CD3"], skills["CD4"]);
        LinkSkills(skills["int3"], skills["intUlt"]);

    }


    public void LinkSkills(Skill downStream, Skill upStream)
    {
        downStream.upStreamSkills.Add(upStream);
        upStream.downStreamSkills.Add(downStream);
    }

    public void ResetSkillTree()
    {
        foreach (var s in skills)
        {
            s.Value.isActive = false;
        }
        Activated = 0;
    }

    public bool ActivateSkill(string name)
    {
        return skills[name].Activate();
    }


    private void AssembleTree()
    {

        //skills a the base of the tree
        List<Skill> roots = new List<Skill>();

        List<Skill>[] treeGraph = new List<Skill>[HIGHT]
        {
            roots,
            //skills higher than the base
             new List<Skill>(),
             new List<Skill>(),
             new List<Skill>(),
             new List<Skill>(),
        };
        //skills without connections
        List<Skill> seeds = new List<Skill>();

        //add the skills in theire respectiv list
        foreach (var s in skills)
        {
            if (s.Value.downStreamSkills.Count < 1)
            {
                if (s.Value.upStreamSkills.Count > 0)
                {
                    roots.Add(s.Value);
                }
                else
                {
                    seeds.Add(s.Value);
                }
            }
        }
        for (int i = 1; i < treeGraph.Length; i++)
        {
            getUpStreams(treeGraph[i - 1], treeGraph[i]);
        }



    }

    private void getUpStreams(List<Skill> skills, List<Skill> output)
    {
        foreach (Skill s in skills)
        {
            foreach (Skill uss in s.upStreamSkills)
            {
                output.Add(uss);
            }
        }
    }

}

