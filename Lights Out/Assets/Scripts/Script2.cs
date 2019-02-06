using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.GetComponent<Script1>().x);
    }
}
