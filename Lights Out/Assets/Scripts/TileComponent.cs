using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    public Material redMaterial, blueMaterial;

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    void Start()
    {
        meshRenderer.material = blueMaterial;
    }

    void OnMouseDown()
    {
        meshRenderer.material = redMaterial;
        //Debug.Log(this.gameObject.name);
    }
}
