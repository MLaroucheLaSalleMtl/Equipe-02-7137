using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 2 February 2019
/// @description Handles everything related to monsters
/// </summary>
public class MonsterHandler : MonoBehaviour
{
    //bi directional link to the game manager
    GameManager Manager { get; set; }

    //all the prefabs of the monsters
    public GameObject[] monsterPrefabs;

    //list that contains all the monsters currently spawned
    public Dictionary<int, Monster> SpawnedMonsters { get; set; }

    private List<MonsterFactory> MonsterFactories { get; set; }

    /// <summary>
    /// Initialize the npc factories
    /// </summary>
    private void InitializeFactories ()
    {
        MonsterFactories = new List<MonsterFactory>();
        MonsterFactories.Add(new RedboarFactory());
        MonsterFactories.Add(new ImplingFactory());
        MonsterFactories.Add(new SkeletonFactory());
        MonsterFactories.Add(new BlueboarFactory());
        MonsterFactories.Add(new GreenboarFactory());
        MonsterFactories.Add(new GoldboarFactory());
        MonsterFactories.Add(new BluedragonFactory());
        MonsterFactories.Add(new GreendragonFactory());
        MonsterFactories.Add(new PurpledragonFactory());
        MonsterFactories.Add(new ReddragonFactory());
    }

    /// <summary>
    /// Returns the smallest spawn id available
    /// </summary>
    /// <returns></returns>
    public int GetFreeSpawnId ()
    {
        int spawnId = 0;
        while (SpawnedMonsters.ContainsKey(spawnId))
        {
            spawnId++;
        }
        return spawnId;
    }

    /// <summary>
    /// Spawns a monster
    /// </summary>
    /// <param name="name"></param>
    public Monster SpawnMonster(MonsterInformation.Monsters name, Position position, string displayName, int level, int maxHp, int currentHp)
    {

        Monster m=null;

        switch (name)
        {
            case MonsterInformation.Monsters.RED_BOAR:
                m = (RedBoar) MonsterFactories.Find(x => x.GetType() == typeof(RedboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.IMPLING:
                m = (Impling)MonsterFactories.Find(x => x.GetType() == typeof(ImplingFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.SKELETON:
                m = (Skeleton)MonsterFactories.Find(x => x.GetType() == typeof(SkeletonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.BLUE_BOAR:
                m = (BlueBoar)MonsterFactories.Find(x => x.GetType() == typeof(BlueboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.GREEN_BOAR:
                m = (GreenBoar)MonsterFactories.Find(x => x.GetType() == typeof(GreenboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.GOLD_BOAR:
                m = (GoldBoar)MonsterFactories.Find(x => x.GetType() == typeof(GoldboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.BLUE_DRAGON:
                m = (BlueDragon)MonsterFactories.Find(x => x.GetType() == typeof(BluedragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.GREEN_DRAGON:
                m = (GreenDragon)MonsterFactories.Find(x => x.GetType() == typeof(GreendragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.PURPLE_DRAGON:
                m = (PurpleDragon)MonsterFactories.Find(x => x.GetType() == typeof(PurpledragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            case MonsterInformation.Monsters.RED_DRAGON:
                m = (RedDragon)MonsterFactories.Find(x => x.GetType() == typeof(ReddragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
                SpawnedMonsters.Add(m.InstanceId, m);
                break;
            default:
                throw new System.Exception("Invalid Monster ID");
        }
        m.Spawn(position);
        SetStatsForLevel(level,m,name);
        return m;
        
    }

    //public Monster SpawnMonster(MonsterInformation.Monsters name, Position position, string displayName, int level, int maxHp, int currentHp)
    //{

    //    Monster m;

    //    switch (name)
    //    {
    //        case MonsterInformation.Monsters.RED_BOAR:
    //            RedBoar newRedBoar = (RedBoar)MonsterFactories.Find(x => x.GetType() == typeof(RedboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newRedBoar.InstanceId, newRedBoar);
    //            newRedBoar.Spawn(position);
    //            return newRedBoar;
    //        case MonsterInformation.Monsters.IMPLING:
    //            Impling newImpling = (Impling)MonsterFactories.Find(x => x.GetType() == typeof(ImplingFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newImpling.InstanceId, newImpling);
    //            newImpling.Spawn(position);
    //            return newImpling;
    //        case MonsterInformation.Monsters.SKELETON:
    //            Skeleton newSkeleton = (Skeleton)MonsterFactories.Find(x => x.GetType() == typeof(SkeletonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newSkeleton.InstanceId, newSkeleton);
    //            newSkeleton.Spawn(position);
    //            return newSkeleton;
    //        case MonsterInformation.Monsters.BLUE_BOAR:
    //            BlueBoar newBlueBoar = (BlueBoar)MonsterFactories.Find(x => x.GetType() == typeof(BlueboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newBlueBoar.InstanceId, newBlueBoar);
    //            newBlueBoar.Spawn(position);
    //            return newBlueBoar;
    //        case MonsterInformation.Monsters.GREEN_BOAR:
    //            GreenBoar newGreenBoar = (GreenBoar)MonsterFactories.Find(x => x.GetType() == typeof(GreenboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newGreenBoar.InstanceId, newGreenBoar);
    //            newGreenBoar.Spawn(position);
    //            return newGreenBoar;
    //        case MonsterInformation.Monsters.GOLD_BOAR:
    //            GoldBoar newGoldBoar = (GoldBoar)MonsterFactories.Find(x => x.GetType() == typeof(GoldboarFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newGoldBoar.InstanceId, newGoldBoar);
    //            newGoldBoar.Spawn(position);
    //            return newGoldBoar;
    //        case MonsterInformation.Monsters.BLUE_DRAGON:
    //            BlueDragon newBlueDrag = (BlueDragon)MonsterFactories.Find(x => x.GetType() == typeof(BluedragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newBlueDrag.InstanceId, newBlueDrag);
    //            newBlueDrag.Spawn(position);
    //            return newBlueDrag;
    //        case MonsterInformation.Monsters.GREEN_DRAGON:
    //            GreenDragon newGreenDrag = (GreenDragon)MonsterFactories.Find(x => x.GetType() == typeof(GreendragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newGreenDrag.InstanceId, newGreenDrag);
    //            newGreenDrag.Spawn(position);
    //            return newGreenDrag;
    //        case MonsterInformation.Monsters.PURPLE_DRAGON:
    //            PurpleDragon newPurpleDrag = (PurpleDragon)MonsterFactories.Find(x => x.GetType() == typeof(PurpledragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newPurpleDrag.InstanceId, newPurpleDrag);
    //            newPurpleDrag.Spawn(position);
    //            return newPurpleDrag;
    //        case MonsterInformation.Monsters.RED_DRAGON:
    //            RedDragon newRedDrag = (RedDragon)MonsterFactories.Find(x => x.GetType() == typeof(ReddragonFactory)).CreateNewNpc(GetFreeSpawnId(), displayName, level, maxHp, currentHp);
    //            SpawnedMonsters.Add(newRedDrag.InstanceId, newRedDrag);
    //            newRedDrag.Spawn(position);
    //            return newRedDrag;
    //    }
    //    SetStats
    //    return m;
    //    throw new System.Exception("invalide monsterID");
    //}

    /// <summary>
    /// Handle the death of a monster
    /// </summary>
    /// <param name="monster"></param>
    public void HandleDeath(Monster monster)
    {
        //Monster dies
        monster.Death();
        StartCoroutine(DestroyMonster(monster.WorldModel, 5f));

        //Check for quests progression
        Manager.questHandler.CheckQuestsProgression(monster);

        //Give xp and money, update UI
        Manager.player.Money += Random.Range(1, 5);
        Manager.player.Experience += Random.Range(4, 7);
        Manager.playerHandler.UpdatePlayerBarUI();
    }

    /// <summary>
    /// Destroy the monster after a certain amount of time
    /// </summary>
    /// <param name="toDestroy"></param>
    /// <param name="delay"></param>
    IEnumerator DestroyMonster(GameObject toDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(toDestroy);
    }

    /// <summary>
    /// Monster blocking for X amount of seconds
    /// </summary>
    /// <param name="npcAnimator"></param>
    /// <param name="delay"></param>
    IEnumerator MonsterBlock(Monster monsterBlocking, float delay)
    {
        yield return new WaitForSeconds(delay);
        monsterBlocking.isBlocking = false;
        monsterBlocking.ActionDone();
    }

    /// <summary>
    /// Monster attacking for X seconds
    /// </summary>
    /// <param name="npcAnimator"></param>
    /// <param name="delay"></param>
    IEnumerator MonsterAttack(Monster monsterAttacking, float delay)
    {
        yield return new WaitForSeconds(delay);
        monsterAttacking.isAttacking = false;
        monsterAttacking.ActionDone();
    }

    /// <summary>
    /// Handle the attack of a Monster
    /// </summary>
    public void HandleAttack (Monster monsterAttacking)
    {
        monsterAttacking.Attack(Manager.player);
        StartCoroutine(MonsterAttack(monsterAttacking, 1.5f));
        Manager.playerHandler.UpdatePlayerBarUI();
    }

    /// <summary>
    /// Execute the hits on the monsters
    /// </summary>
    /// <param name="hitAmount"></param>
    public void ExecuteHits(int hitAmount, Monster[] monstersGettingHit)
    {
        foreach (Monster monster in monstersGettingHit)
        {
            if (!monster.isDead)
            {
                monster.Block();
                RemoveHp(monster, hitAmount);
                StartCoroutine(MonsterBlock(monster, 1.5f));
            }
        }
    }

    /// <summary>
    /// Removes a certain amount of hp from a monster and handles the death if it's the case
    /// </summary>
    /// <param name="monsterToRemoveHp"></param>
    /// <param name="amount"></param>
    public void RemoveHp(Monster monsterToRemoveHp, int amount)
    {
        int value = Mathf.Abs(amount);
        monsterToRemoveHp.RemoveHp(value);
        if (monsterToRemoveHp.CurrentHp <= 0)
        {
            HandleDeath(monsterToRemoveHp);
        }
    }

    private void Awake()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnedMonsters = new Dictionary<int, Monster>();
        InitializeFactories();
    }


    //weak monster should have a difficulty of 1,player around 2,hard monster and boss 3 and above
    public virtual void GetStatsForLevel(int level, out int maxHp, out int attackDamage, float difficulty)
    {
        int baseHp = 100;
        int baseAttack = 10;

        float coeficient = 1.1f;
        float exponent = (Mathf.Sqrt(difficulty) * level) - 5;
        float exponentA = (Mathf.Sqrt(2) * level) - 5;


        maxHp = (int)(baseHp * Mathf.Pow(coeficient, exponent));
        attackDamage = (int)(baseAttack * Mathf.Pow(coeficient, exponentA));
    }



    public void SetStatsForLevel(int level,Monster m,MonsterInformation.Monsters type)
    {
        GetStatsForLevel(level, out int maxHp, out int strenght, MonsterInformation.monsterDificulties[type]);
        m.SetStats(maxHp, strenght);
    }


}
