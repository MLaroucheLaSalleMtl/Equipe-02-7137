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

    protected int hp;
    protected Position worldPos;
    protected int level;
    protected string name;

    public abstract int HP { get; }
    public abstract Position WorldPosition { get; set; }
    public abstract int Level { get; }
    public abstract string Name { get; protected set; }

    public abstract void GiveHp(int amount);
    public abstract void RemoveHp(int amount);
    public abstract void LevelUp();
    public abstract void LevelDown();
    public abstract void SetLevel(int level);
    public abstract void Move(Position newPosition);

}
