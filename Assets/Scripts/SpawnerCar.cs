using UnityEngine;

public class SpawnerCar : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] float minSpawnTime = .5f;
    [SerializeField] float maxSpawnTime = 2f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Random.Range(minSpawnTime, maxSpawnTime))
        {
            SpawnCar();
            timer = 0f;
        }
    }

    void SpawnCar()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Vector3 spawnPosition = spawnPoint.position;
        Quaternion spawnRotation = Quaternion.identity;

        if (spawnIndex == 1)
        {
            // Rotate car to face left
            spawnRotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else
        {
            // Rotate car to face right
            spawnRotation = Quaternion.Euler(0f, 0f, 90f);
        }

        GameObject car = Instantiate(carPrefab, spawnPosition, spawnRotation);
    }
}