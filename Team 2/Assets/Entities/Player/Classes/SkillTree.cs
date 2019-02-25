using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities.Player.Classes
{
    class SkillTree
    {
        List<Skill> skills;
        const int HIGHT = 5;
        const int WIDTH = 5;

        public SkillTree()
        {

        }


        public void LinkSkills(Skill downStream,Skill upStream)
        {
            downStream.upStreamSkills.Add(upStream);
            upStream.downStreamSkills.Add(downStream);
        }

        public void ResetSkillTree()
        {
            foreach(var s in skills)
            {
                s.isActive = false;
            }
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
            foreach(Skill s in skills)
            {
                if(s.downStreamSkills.Count<1)
                {
                    if(s.upStreamSkills.Count>0)
                    {
                        roots.Add(s);
                    }
                    else
                    {
                        seeds.Add(s);
                    }
                }
            }
            for(int i=1;i<treeGraph.Length;i++)
            {
                getUpStreams(treeGraph[i - 1], treeGraph[i]);
            }

            

        }

        private void getUpStreams(List<Skill> skills, List<Skill> output)
        {
            foreach(Skill s in skills)
            {
                foreach(Skill uss in s.upStreamSkills)
                {
                    output.Add(uss);
                }
            }
        }

    }
}
