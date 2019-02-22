﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @descripton Information about the npcs (rates, etc.)
/// @date 11 FEB 2019
/// @author Samuel Paquette
/// </summary>
public static class NPCInformation
{
    public enum NPCNames
    {
        GOBLIN,
        IMPLING,
        SHELLCRAB,
    }

    public enum NPCPrefabId
    {
        GOBLIN,
        IMPLING,
        SHELLCRAB,
    }

    public const int HPRate = 10;
}
