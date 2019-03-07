using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeButton : MonoBehaviour
{
    [SerializeField] GameObject player;
    Player playerScript;
    SkillTree skillTree;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerAdapter>().p;
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
    }
}
