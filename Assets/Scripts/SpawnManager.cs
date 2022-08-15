using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    int enemyRemains = 10;
    float spawnRate = 1;
    float spawnTime = 0;
    Vector3 spawnPosition = new Vector3(-70,0,-60);
    private void Start()
    {
        
    }

    private void Update()
    {
        if (spawnTime < 0 && enemyRemains > 0)
        {
            SpawnEnemy();
            spawnTime = spawnRate;
        }
        else
            spawnTime -= Time.deltaTime;
    }
    void SpawnEnemy()
    {
        enemyPrefab.GetComponent<Enemy>().Number = 11 - enemyRemains;
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        enemyRemains--;
    }
}
