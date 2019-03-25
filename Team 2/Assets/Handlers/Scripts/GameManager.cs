using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description The bi-directional link between all the handlers needed for the gameplay of the player
/// </summary>
public class GameManager : MonoBehaviour
{

    public Player player { get; set; }
    public MonsterHandler monsterHandler { get; set; }
    public PlayerHandler playerHandler { get; set; }
    public ItemHandler itemHandler { get; set; }
    public CombatHandler combatHandler { get; set; }
    public NPCHandler npcHandler { get; set; }
    public QuestHandler questHandler { get; set; }
    public DialogueHandler dialogueHandler { get; set; }

    public Interactable interactableFocus { get; set; }
    public LayerMask interactableMask;
    public NPC talkingTo;

    /// <summary>
    /// Called when the game is launched
    /// </summary>
    void Awake()
    {
        monsterHandler = GetComponent<MonsterHandler>();
        playerHandler = GetComponent<PlayerHandler>();
        itemHandler = GetComponent<ItemHandler>();
        combatHandler = GetComponent<CombatHandler>();
        npcHandler = GetComponent <NPCHandler>();
        questHandler = GetComponent<QuestHandler>();
        dialogueHandler = GetComponent<DialogueHandler>();

        playerHandler.CreatePlayer("Satucre", 1, 10, 1, 0, 0, 0, 150, new WarriorClass(), GameObject.Find("Player"));

    }

    private void Start()
    {
        //Spawn monsters for testing purposes
        //monsterHandler.SpawnMonster(MonsterInformation.Monsters.SKELETON, new Position(-11, 31, -5), "Skeleton", 1, 5, 5);
        //monsterHandler.SpawnMonster(MonsterInformation.Monsters.SKELETON, new Position(-5, 31, -5), "Skeleton", 1, 5, 5);
        //monsterHandler.SpawnMonster(MonsterInformation.Monsters.SKELETON, new Position(0, 31, -5), "Skeleton", 1, 5, 5);
    }

    /// <summary>
    /// When the users clicks with his mouse on the first ability
    /// </summary>
    public void FirstAbilityButtonClick ()
    {
        combatHandler.Attack(0);
    }

    /// <summary>
    /// When the users clicks with his mouse on the second ability
    /// </summary>
    public void SecondAbilityButtonClick()
    {
        combatHandler.Attack(1);
    }

    /// <summary>
    /// When the users clicks with his mouse on the third ability
    /// </summary>
    public void ThirdAbilityButtonClick()
    {
        combatHandler.Attack(2);
    }

    /// <summary>
    /// When the users clicks with his mouse on the fourth ability
    /// </summary>
    public void FourthAbilityButtonClick()
    {
        combatHandler.Attack(3);
    }

    /// <summary>
    /// Interact with something
    /// </summary>
    public void Interact ()
    {
        //does a raycast to where the mouse is pointing at
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        //the hit of the raycast
        RaycastHit hit;

        //checks if the raycast hit something
        if (Physics.Raycast(raycast, out hit, 100, interactableMask))
        {
            //get the interactable component of what we hit with the raycast
            Interactable interactableHit = hit.collider.GetComponent<Interactable>();

            //if its null, its because what we hit isnt an interactable
            if (interactableHit != null)
            {
                interactableFocus = interactableHit;
                interactableFocus.OnInteract(player);
                StartCoroutine(ExecuteFacing(1f));
                NPC npc = hit.collider.GetComponent<NPC>();
                if (npc != null)
                {
                    talkingTo = npc;
                }
            }
        }
    }

    /// <summary>
    /// Execute the facing coroutine
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator ExecuteFacing(float delay)
    {
        yield return new WaitForSeconds(delay);
        interactableFocus = null;
    }

    /// <summary>
    /// Faces the interactable object that we clicked on
    /// </summary>
    private void FaceInteractable ()
    {
        //vector substraction to get the direction the player should look towards
        Vector3 direction = (interactableFocus.transform.position - player.WorldModel.transform.position).normalized;
        //creates the quaternion with our rotation vector
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        //change the actual rotation of our player with a slerp (so its not instantly but smooth)
        player.WorldModel.transform.rotation = Quaternion.Slerp(player.WorldModel.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /// <summary>
    /// get the distance between the interactable and the player
    /// </summary>
    /// <returns></returns>
    public float DistanceToPlayer(Interactable interactable)
    {
        return Vector3.Distance(player.WorldModel.transform.position, interactable.transform.position);
    }

    /// <summary>
    /// Called each game tick
    /// </summary>
    void Update()
    {
        if (!player.IsDead)
        {
            if (Input.GetButtonDown("Ability 1"))
            {
                FirstAbilityButtonClick();
            }
            else if (Input.GetButtonDown("Ability 2"))
            {
                SecondAbilityButtonClick();
            }
            else if (Input.GetButtonDown("Ability 3"))
            {
                ThirdAbilityButtonClick();
            }
            else if (Input.GetButtonDown("Ability 4"))
            {
                FourthAbilityButtonClick();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
            if (interactableFocus != null)
            {
                FaceInteractable();
            }
            if (talkingTo != null)
            {
                if (DistanceToPlayer(talkingTo) > talkingTo.actionRadius)
                {
                    dialogueHandler.QuitDialogue();
                }
            }
        }
    }
}
