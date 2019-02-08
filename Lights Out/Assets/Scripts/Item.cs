using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string name;
    public float damage;
    public float durability;

    public Item(string name, float damage, float durability)
    {
        this.name = name;
        this.damage = damage;
        this.durability = durability;
    }
}
