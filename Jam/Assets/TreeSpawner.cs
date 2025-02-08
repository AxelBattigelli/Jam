using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public Terrain terrain;

    public int treeCount = 100;
    public float minYPos = 0;

    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 position = GetRandomPositionOnTerrain();
            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionOnTerrain()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;

        float minXPos = terrain.transform.position.x;
        float minZPos = terrain.transform.position.z;

        float randomX = Random.Range(minXPos, minXPos + terrainWidth);
        float randomZ = Random.Range(minZPos, minZPos + terrainLength);
        float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrain.transform.position.y;

        return new Vector3(randomX, y, randomZ);
    }
}
