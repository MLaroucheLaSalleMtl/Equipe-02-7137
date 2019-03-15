using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description Handles everything related to npcs
/// </summary>
public class NPCHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }

    //all the prefabs of the npcs
    public GameObject[] npcPrefabs;

    //list that contains all te npcs currently spawned
    public Dictionary<int, NPC> SpawnedNPCs { get; set; }

    private List<MonsterFactory> NPCFactories { get; set; }

    /// <summary>
    /// Initialize the npc factories
    /// </summary>
    private void InitializeFactories ()
    {
        NPCFactories = new List<MonsterFactory>();
        NPCFactories.Add(new RedboarFactory());
        NPCFactories.Add(new ImplingFactory());
        NPCFactories.Add(new ShellCrabFactory());
        NPCFactories.Add(new BlueboarFactory());
        NPCFactories.Add(new GreenboarFactory());
        NPCFactories.Add(new GoldboarFactory());
        NPCFactories.Add(new BluedragonFactory());
        NPCFactories.Add(new GreendragonFactory());
        NPCFactories.Add(new PurpledragonFactory());
        NPCFactories.Add(new ReddragonFactory());
    }

    /// <summary>
    /// Returns the smallest spawn id available
    /// </summary>
    /// <returns></returns>
    public int GetFreeSpawnId ()
    {
        int spawnId = 0;
        while (SpawnedNPCs.ContainsKey(spawnId))
        {
            spawnId++;
        }
        return spawnId;
    }

    /// <summary>
    /// Spawns a npc
    /// </summary>
    /// <param name="name"></param>
    public void SpawnNPC(NPCInformation.NPCNames name, Position position, string displayName, int level, int maxHp, int currentHp)
    {
        switch (name)
        {
            case NPCInformation.NPCNames.RED_BOAR:
                RedBoar newRedBoar = (RedBoar) NPCFactories.Find(x => x.GetType() == typeof(RedboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newRedBoar.InstanceId, newRedBoar);
                newRedBoar.Spawn(position);
                break;
            case NPCInformation.NPCNames.IMPLING:
                Impling newImpling = (Impling)NPCFactories.Find(x => x.GetType() == typeof(ImplingFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newImpling.InstanceId, newImpling);
                newImpling.Spawn(position);
                break;
            case NPCInformation.NPCNames.SHELLCRAB:
                ShellCrab newShellCrab = (ShellCrab)NPCFactories.Find(x => x.GetType() == typeof(ShellCrabFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newShellCrab.InstanceId, newShellCrab);
                newShellCrab.Spawn(position);
                break;
            case NPCInformation.NPCNames.BLUE_BOAR:
                BlueBoar newBlueBoar = (BlueBoar)NPCFactories.Find(x => x.GetType() == typeof(BlueboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newBlueBoar.InstanceId, newBlueBoar);
                newBlueBoar.Spawn(position);
                break;
            case NPCInformation.NPCNames.GREEN_BOAR:
                GreenBoar newGreenBoar = (GreenBoar)NPCFactories.Find(x => x.GetType() == typeof(GreenboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newGreenBoar.InstanceId, newGreenBoar);
                newGreenBoar.Spawn(position);
                break;
            case NPCInformation.NPCNames.GOLD_BOAR:
                GoldBoar newGoldBoar = (GoldBoar)NPCFactories.Find(x => x.GetType() == typeof(GoldboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newGoldBoar.InstanceId, newGoldBoar);
                newGoldBoar.Spawn(position);
                break;
            case NPCInformation.NPCNames.BLUE_DRAGON:
                BlueDragon newBlueDrag = (BlueDragon)NPCFactories.Find(x => x.GetType() == typeof(BluedragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newBlueDrag.InstanceId, newBlueDrag);
                newBlueDrag.Spawn(position);
                break;
            case NPCInformation.NPCNames.GREEN_DRAGON:
                GreenDragon newGreenDrag = (GreenDragon)NPCFactories.Find(x => x.GetType() == typeof(GreendragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newGreenDrag.InstanceId, newGreenDrag);
                newGreenDrag.Spawn(position);
                break;
            case NPCInformation.NPCNames.PURPLE_DRAGON:
                PurpleDragon newPurpleDrag = (PurpleDragon)NPCFactories.Find(x => x.GetType() == typeof(PurpledragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newPurpleDrag.InstanceId, newPurpleDrag);
                newPurpleDrag.Spawn(position);
                break;
            case NPCInformation.NPCNames.RED_DRAGON:
                RedDragon newRedDrag = (RedDragon)NPCFactories.Find(x => x.GetType() == typeof(ReddragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newRedDrag.InstanceId, newRedDrag);
                newRedDrag.Spawn(position);
                break;
        }
    }

    /// <summary>
    /// Handle the death of a npc
    /// </summary>
    /// <param name="npc"></param>
    public void HandleDeath(NPC npc)
    {
        npc.Death();
        StartCoroutine(DestroyNPC(npc.WorldModel, 5f));
        Manager.player.Money += Random.Range(1, 5);
        Manager.player.Experience += Random.Range(4, 7);
        Manager.playerHandler.UpdatePlayerBarUI();
    }

    /// <summary>
    /// Destroy the npc after a certain amount of time
    /// </summary>
    /// <param name="toDestroy"></param>
    /// <param name="delay"></param>
    IEnumerator DestroyNPC(GameObject toDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(toDestroy);
    }

    /// <summary>
    /// NPC blocking for X amount of seconds
    /// </summary>
    /// <param name="npcAnimator"></param>
    /// <param name="delay"></param>
    IEnumerator NPCBlock(NPC npcBlocking, float delay)
    {
        yield return new WaitForSeconds(delay);
        npcBlocking.isBlocking = false;
    }

    /// <summary>
    /// Execute the hits on the npcs
    /// </summary>
    /// <param name="hitAmount"></param>
    public void ExecuteHits(int hitAmount, NPC[] npcsGettingHit)
    {
        foreach (NPC npc in npcsGettingHit)
        {
            npc.Block();
            RemoveHp(npc, hitAmount);
            StartCoroutine(NPCBlock(npc, 1.5f));
        }
    }

    /// <summary>
    /// Removes a certain amount of hp from a npc and handles the death if it's the case
    /// </summary>
    /// <param name="npcToRemoveHp"></param>
    /// <param name="amount"></param>
    public void RemoveHp(NPC npcToRemoveHp, int amount)
    {
        int value = Mathf.Abs(amount);
        npcToRemoveHp.RemoveHp(value);
        if (npcToRemoveHp.CurrentHp <= 0)
        {
            HandleDeath(npcToRemoveHp);
        }
    }

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnedNPCs = new Dictionary<int, NPC>();
        InitializeFactories();
    }

}
