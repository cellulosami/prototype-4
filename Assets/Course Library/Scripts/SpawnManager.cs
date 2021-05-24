using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject pickupPrefab;
    private float spawnRange = 9.0f;
    private float enemyDelay = 1.5f;
    private float pickupDelay = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", enemyDelay);
        Invoke("SpawnPickup", pickupDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenEnemySpawnPoint() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPoint = new Vector3(spawnPosX, 20, spawnPosZ);
        return spawnPoint;
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, GenEnemySpawnPoint(), enemyPrefab.transform.rotation);

        float spawnDelay = Random.Range(2, 8);
        Invoke("SpawnEnemy", spawnDelay);
    }

    Vector3 GenPickupSpawnPoint() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPoint = new Vector3(spawnPosX, 0.4f, spawnPosZ);
        return spawnPoint;
    }

    void SpawnPickup() {
        Instantiate(pickupPrefab, GenPickupSpawnPoint(), pickupPrefab.transform.rotation);
        
        float spawnDelay = Random.Range(16, 24);
        Invoke("SpawnPickup", spawnDelay);
    }
}
