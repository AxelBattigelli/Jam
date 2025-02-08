using UnityEngine;

public class StairSpawner : MonoBehaviour
{
    public GameObject endObject;

    public GameObject stairPrefab;
    public Transform spawnPoint;
    private bool isTrue;
    public bool canSpawn = true;
    private bool isTrueEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSpawn)
        {
            SpawnStair();
        }
    }

    void SpawnStair()
    {
        if (!isTrue && LightManager.GlobalVariables.totalLightsOff < 10)
        {
            Vector3 newPosition = spawnPoint.position + new Vector3(0, 6, 0);
            GameObject newStair = Instantiate(stairPrefab, newPosition, Quaternion.identity);
            isTrue = true;
        }
        if (isTrueEnd != true && LightManager.GlobalVariables.totalLightsOff >= 10)
        {
             Vector3 newPosition = spawnPoint.position + new Vector3(0, 9, 0);
             newPosition.x = -1;
             newPosition.z = -3;
             GameObject newEndObject = Instantiate(endObject, newPosition, Quaternion.identity);
            isTrueEnd = true;
        }
    }
}
