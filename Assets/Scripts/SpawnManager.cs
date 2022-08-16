using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private int enemyRemains = 10;
    private float spawnRate = 1;
    private float spawnTime = 0;
    private Vector3 spawnPosition = new Vector3(-70,0,-60);
    private int waveNumber;
    private float timerBetweenWaves = 10f;
    bool coroutineStarted;
    MainController mainController;
    private void Awake()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
    }
    private void Start()
    {
        waveNumber = 1;
        coroutineStarted = false;
    }

    private void Update()
    {
        if (mainController.Instance.gameover)
            return;
        if (spawnTime <= 0 && enemyRemains > 0)
        {
            SpawnEnemy();
            spawnTime = spawnRate;
        }
        else if (enemyRemains > 0)
            spawnTime -= Time.deltaTime;   
        if (enemyRemains == 0 && !coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(waveCoroutine());
        }
    }
    void SpawnEnemy()
    {
        enemyPrefab.GetComponent<Enemy>().Number = 11 - enemyRemains;
        Debug.Log(enemyPrefab.GetComponent<Enemy>().Health);
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        enemyRemains--;
    }
    IEnumerator waveCoroutine()
    {
        yield return new WaitForSeconds(timerBetweenWaves);
        waveNumber++;
        enemyRemains = 10;
        coroutineStarted = false;
        enemyPrefab.GetComponent<Enemy>().HealthBuff(waveNumber);
    }
}
