using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>()
    {
        {"Bronze Sword", new Item("Bronze Sword", 5.0f, 1.0f) },
        { "Iron Sword", new Item("Iron Sword", 10.0f, 2.0f) }
    };

    void Start()
    {
        Debug.LogFormat("The damage value of the bronze sword is: {0}", itemDictionary["Bronze Sword"].damage);
    }
}
