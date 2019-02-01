using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public int width, height;
    [HideInInspector] public List<GameObject> tilePrefabList;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }
    
    void SpawnObjects()
    {
        for (int x = 0; x < width; x++)
        {
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
            }
        }
    }
}
