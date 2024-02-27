using System;
using UnityEngine;

[Serializable]
public class Army
{
    public string Name;
    public string Description;
    public GameObject Prefab;
    public int Health;
    public int DPS;
    public float MoveSpeed;
    public int Cost;
    public int DamageCastle;

    public Army(string name, string description, GameObject prefab, int health, int damage, float moveSpeed, int cost, int damageCastle)
    {
        Name = name;
        Description = description;
        Prefab = prefab;
        Health = health;
        DPS = damage;
        MoveSpeed = moveSpeed;
        Cost = cost;
        DamageCastle = damageCastle;
    }
}
