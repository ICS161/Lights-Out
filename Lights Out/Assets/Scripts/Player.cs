using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var itemDictionary = ItemDatabase.itemDictionary;
        Debug.LogFormat("The damage value of the iron sword is: {0}", itemDictionary["Iron Sword"].damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
