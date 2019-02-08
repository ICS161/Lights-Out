using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileSpawner : MonoBehaviour
{
    public int width, height;
    [HideInInspector] public List<GameObject> tilePrefabList;

    private List<List<TileComponent>> tileGrid = new List<List<TileComponent>>(); // tileGrid = []

    private UnityEvent OnTilesFlippedEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("Number of columns in tileGrid before spawning objects: {0}", tileGrid.Count);
        //Debug.LogFormat("Number of rows in tileGrid before spawning objects: {0}", tileGrid[0].Count); // OutOfRangeException
        SpawnObjects();
        Debug.LogFormat("Number of columns in tileGrid after spawning objects: {0}", tileGrid.Count);
        Debug.LogFormat("Number of rows in tileGrid after spawning objects: {0}", tileGrid[0].Count);

        //TileComponent.OnClickedEvent  // You have to listen to an INSTANCE of the class

        OnTilesFlippedEvent.AddListener(CheckWin);
    }

    void Update()
    {
        //CheckWin(); // Every frame we're doing an O(W * H) check across our entire grid
    }

    void SpawnObjects()
    {
        for (int x = 0; x < width; x++)
        {
            tileGrid.Add(new List<TileComponent>());   // tileGrid.append([])
            for (int y = 0; y < height; y++)
            {
                int randomIndex = Random.Range(0, tilePrefabList.Count);
                GameObject randomTilePrefab = tilePrefabList[randomIndex];
                Vector3 spawnPosition = new Vector3(x, y, 0);

                //Instantiate(randomTilePrefab, spawnPosition, Quaternion.identity, this.transform);
                //GameObject newTileObject = Instantiate(randomTilePrefab, spawnPosition, Quaternion.identity);
                //newTileObject.transform.SetParent(this.transform);

                GameObject newTileObject = Instantiate(randomTilePrefab, this.transform);
                newTileObject.transform.localPosition = spawnPosition;
                TileComponent newTileComponent = newTileObject.GetComponent<TileComponent>();
                newTileComponent.Init(x, y);

                newTileComponent.OnClickedEvent.AddListener(FlipTilesAdjacentTo);

                tileGrid[x].Add(newTileComponent);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bool coinFlip = Random.value <= 0.5f;
                if (coinFlip)
                {
                    //newTileComponent.ToggleMaterial();
                    FlipTilesAdjacentTo(x, y);
                }
            }
        }
    }

    void FlipTilesAdjacentTo(int x, int y)
    {
        Debug.LogFormat("A tile was clicked at [{0}][{1}]", x, y);
        //tileGrid[x - 1][y].ToggleMaterial();  //Left
        //tileGrid[x + 1][y].ToggleMaterial();  //Right
        //tileGrid[x][y - 1].ToggleMaterial();  //Down
        //tileGrid[x][y + 1].ToggleMaterial();  //Up
        CheckInBoundsAndFlip(x, y);
        CheckInBoundsAndFlip(x - 1, y);
        CheckInBoundsAndFlip(x + 1, y);
        CheckInBoundsAndFlip(x, y - 1);
        CheckInBoundsAndFlip(x, y + 1);

        //CheckWin();
        OnTilesFlippedEvent.Invoke();
    }

    bool IsValidCell(int x, int y)
    {
        return (0 <= x && x < tileGrid.Count &&
                0 <= y && y < tileGrid[0].Count);
    }

    void CheckInBoundsAndFlip(int x, int y)
    {
        if (IsValidCell(x, y))
            tileGrid[x][y].CycleMaterial();
    }

    void CheckWin()
    {
        TileColor firstObjectColor = tileGrid[0][0].m_color;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (tileGrid[x][y].m_color != firstObjectColor)
                {
                    return;
                }
            }
        }
        Debug.Log("YOU WIN!!!");
    }
}