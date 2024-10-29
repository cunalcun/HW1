using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;     
    public float spawnInterval = 5f;  
    public float spawnRange = 10f;
    private float spawnTimer = 0f; 

    void Update()
    {

        spawnTimer += Time.deltaTime;

   
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange), 
            50,
            Random.Range(transform.position.z - spawnRange, transform.position.z + spawnRange)
        );

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        GameManager.instance.EnemySpawned();
    }
}
