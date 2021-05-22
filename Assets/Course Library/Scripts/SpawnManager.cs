using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    private float startDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPoint() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPoint = new Vector3(spawnPosX, 20, spawnPosZ);
        return spawnPoint;
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);

        float spawnDelay = Random.Range(2, 8);
        Invoke("SpawnEnemy", spawnDelay);
    }
}
