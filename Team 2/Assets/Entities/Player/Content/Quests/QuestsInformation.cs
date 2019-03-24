﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 19 MARS 2019
/// @description Information about quests
/// </summary>
public static class QuestsInformation
{

    /// <summary>
    /// Ids of the quests
    /// </summary>
    public enum QuestIds
    {
        TUTORIAL_QUEST,
    }

    public enum StateTypes
    {
        KILL_STATE,
        GATHERING_STATE,
        TALKING_STATE,
    }

}
