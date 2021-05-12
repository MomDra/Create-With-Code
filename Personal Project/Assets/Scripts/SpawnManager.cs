using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    GameObject powerup;

    float zEnemySpawn = 12;
    float xSpawnRange = 13;
    float zPowerupRange = 5;
    float ySpawn = 0.7f;

    float powerupSpawnTime = 5;
    float enemySpawnTime = 1;
    float startDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
    }
    
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}

