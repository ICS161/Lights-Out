using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntIntUnityEvent : UnityEvent<int, int> { }

public enum TileColor
{
    RED,
    BLUE,
    GREEN
}

public class TileComponent : MonoBehaviour
{
    public Material redMaterial, blueMaterial, greenMaterial;
    private int gridX, gridY;

    public TileColor m_color;

    public IntIntUnityEvent OnClickedEvent = new IntIntUnityEvent();

    private MeshRenderer meshRenderer;
    private Dictionary<TileColor, Material> colorToMaterialDict = new Dictionary<TileColor, Material>();    // d = {}
    // unordered_map<TileColor, Material> d();

    void Awake()
    {
        colorToMaterialDict.Add(TileColor.RED, redMaterial);
        colorToMaterialDict.Add(TileColor.BLUE, blueMaterial);
        colorToMaterialDict.Add(TileColor.GREEN, greenMaterial);

        meshRenderer = this.GetComponent<MeshRenderer>();

        SetMaterial(TileColor.BLUE);
        //isRed = false;
        //m_color = TileColor.BLUE;
        //meshRenderer.material = blueMaterial;
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

    public void CycleMaterial()
    {
        switch (m_color)
        {
            case TileColor.RED:
                SetMaterial(TileColor.BLUE);
                //m_color = TileColor.BLUE;
                //meshRenderer.material = blueMaterial;
                break;
            case TileColor.BLUE:
                SetMaterial(TileColor.GREEN);
                //m_color = TileColor.GREEN;
                //meshRenderer.material = greenMaterial;
                break;
            case TileColor.GREEN:
                SetMaterial(TileColor.RED);
                //m_color = TileColor.RED;
                //meshRenderer.material = redMaterial;
                break;
        }
        //isRed = !isRed;
        //meshRenderer.material = isRed ? redMaterial : blueMaterial;
    }

    void SetMaterial(TileColor newColor)
    {
        m_color = newColor;
        meshRenderer.material = colorToMaterialDict[newColor];
    }
}
