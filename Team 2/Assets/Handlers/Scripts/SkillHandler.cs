﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    Player playerScript;
    SkillTree skillTree;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();
        playerScript = manager.player;
        skillTree = new SkillTree(playerScript);
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateSkill(string name)
    {
        skillTree.ActivateSkill(name);
        manager.playerHandler.UpdatePlayerBarUI();
    }
}
