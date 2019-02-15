﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 15 FEB 19
/// @description The abstract design of the creator (monster factory)
/// </summary>
public abstract class MonsterFactory
{
    public abstract NPC GetNPC();
}
