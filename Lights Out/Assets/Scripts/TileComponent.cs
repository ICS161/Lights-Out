using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntIntUnityEvent : UnityEvent<int, int> { }

public class TileComponent : MonoBehaviour
{
    public Material redMaterial, blueMaterial;
    private int gridX, gridY;

    public bool isRed;

    public IntIntUnityEvent OnClickedEvent = new IntIntUnityEvent();

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        isRed = false;
        meshRenderer.material = blueMaterial;
    }

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        meshRenderer.material = redMaterial;
        //Debug.Log(this.gameObject.name);
        OnClickedEvent.Invoke(gridX, gridY);
        //ToggleMaterial();
    }

    public void Init(int x, int y)
    {
        this.gridX = x;
        this.gridY = y;
    }

    public void ToggleMaterial()
    {
        isRed = !isRed;
        meshRenderer.material = isRed ? redMaterial : blueMaterial;
    }
}
