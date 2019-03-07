using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    [SerializeField] GameObject player;
    Player playerScript;
    SkillTree skillTree;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerAdapter>().GetComponent<Player>();
        skillTree = new SkillTree(playerScript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateSkill(string name)
    {
        skillTree.Skills[name].Activate();
    }

}
