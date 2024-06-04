using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 1f;
    public int enemiesPerWave = 5;
    public int currentWave = 0;
    public int enemiesSpawned = 0;
    public int enemiesKilled = 0;
    public bool waveActive = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        StartCoroutine(StartWave());
    }

    void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += HandleOnEmemyDeath;
    }

    void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= HandleOnEmemyDeath;
    }

        private void HandleOnEmemyDeath()
    {
        enemiesKilled++;
        Debug.Log("Enemies Killed = " + enemiesKilled);
    }

    public IEnumerator StartWave()
    {   
        Debug.Log("Wave " + currentWave);
        waveActive = true;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        yield return new WaitForSeconds(timeBetweenWaves);
        waveActive = false;
    }

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        enemiesSpawned++;
    }

   



    public void Update()
    {
        if (enemiesKilled == enemiesPerWave && !waveActive)
        {
            currentWave++;
            enemiesKilled = 0;
            StartCoroutine(StartWave());
        }
    }
}
