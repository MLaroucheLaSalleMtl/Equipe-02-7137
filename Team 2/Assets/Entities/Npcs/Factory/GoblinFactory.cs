using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/
public class GoblinFactory : MonsterFactory
{
    public override NPC GetNPC()
    {
        throw new System.NotImplementedException();
    }
}
