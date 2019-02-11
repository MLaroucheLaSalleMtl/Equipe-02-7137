using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 1 February 2019
/// @description The abstract design of an entity in the game
/// </summary>
public abstract class Entity
{

    protected int maxHp;
    protected int currentHp;
    protected Position worldPos;
    protected int level;
    protected string displayName;

    public abstract int MaxHP { get; }
    public abstract int CurrentHp { get; }
    public abstract Position WorldPosition { get; set; }
    public abstract int Level { get; }
    public abstract string DisplayName { get; }

    public abstract void GiveHp(int amount);
    public abstract void RemoveHp(int amount);
    public abstract void LevelUp();
    public abstract void LevelDown();
    public abstract void SetLevel(int level);
    public abstract void Move(Position newPosition);
    public abstract void Attack(Entity toAttack);

}
