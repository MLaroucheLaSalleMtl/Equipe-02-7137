using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 25 FEB 2019
/// @description All useful information related to the classes
/// </summary>
public static class ClassesInformation
{

    /// <summary>
    /// Ids of the classes
    /// </summary>
    public enum ClassesId
    {
        WARRIOR,
        RANGER,
        MAGE,
    }

    /// <summary>
    /// Indexes for the different attacks
    /// </summary>
    public enum WarriorKeyIndex
    {
        NONE = -1,
        BASIC_ATTACK,
        SWING_ATTACK,
    }

}
