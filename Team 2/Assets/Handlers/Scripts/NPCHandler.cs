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
        NPCFactories.Add(new GoblinFactory());
        NPCFactories.Add(new ImplingFactory());
        NPCFactories.Add(new ShellCrabFactory());
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
            case NPCInformation.NPCNames.GOBLIN:
                Goblin newGoblin = (Goblin) NPCFactories.Find(x => x.GetType() == typeof(GoblinFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedNPCs.Add(newGoblin.InstanceId, newGoblin);
                newGoblin.Spawn(position);
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
