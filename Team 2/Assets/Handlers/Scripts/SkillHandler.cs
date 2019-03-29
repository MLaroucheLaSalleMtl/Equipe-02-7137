using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        skillTree = new SkillTree(manager);
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateSkill(string name)
    {
        if(skillTree.ActivateSkill(name))
        {
            GameObject.Find(name).GetComponent<Button>().enabled = false;
        }
        manager.playerHandler.UpdatePlayerBarUI();
    }

    public void ResetSkillTree()
    {
        skillTree.ResetSkillTree();
        manager.player.Class.ResetSkills();
        foreach(var b in skillTree.Skills)
        {
            GameObject.Find(b.Key).GetComponent<Button>().enabled = true;
        }
        manager.playerHandler.UpdatePlayerBarUI();
    }
}
