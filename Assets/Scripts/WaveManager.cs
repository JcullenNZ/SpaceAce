using System.Collections;
using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }

    public static event Action<int> OnWaveComplete = delegate { };
    public static event Action<int, int, float> OnNewWaveStart = delegate { };

[Header ("---------Enemy Settings + Spawn Points---------")]
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
[ Header ("---------Wave Settings---------")]
    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 1f;
    public int enemiesPerWave = 5;
    public int currentWave = 0;
    public int enemiesSpawned = 0;
    public int enemiesKilled = 0;
    public bool waveActive = false;
    public int waveScore;
    public int waveTimer = 30;





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

    void OnEnable() //Subcribing to Actions
    {
        EnemyHealth.OnEnemyDeath += HandleOnEmemyDeath;
    }

    void OnDisable() //Unsubscribing from Actions
    {
        EnemyHealth.OnEnemyDeath -= HandleOnEmemyDeath;
    }

        private void HandleOnEmemyDeath(int scoreValue)
    {
        enemiesKilled++;
        Debug.Log("Enemies Killed = " + enemiesKilled);
    }

    public IEnumerator StartWave()
    {   
        OnNewWaveStart.Invoke(waveTimer, currentWave, timeBetweenWaves);
        yield return new WaitForSeconds(timeBetweenWaves);
        waveScore = currentWave * 100;
        
        waveActive = true;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        waveActive = false;
    }

    public void SpawnEnemy()
    {   
        int randomEnemy;
        if (currentWave <= 1) //Making it scale in difficulty
        {
           randomEnemy = 0;
        }
        else if (currentWave <= 3)
        {
            randomEnemy = UnityEngine.Random.Range(0, 1);
        }
        else
        {
            randomEnemy = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        }
        int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        enemiesSpawned++;
    }

    public void Update()
    {
        if (enemiesKilled == enemiesPerWave && !waveActive)
        {
            int score = waveScore;
            currentWave++;
            OnWaveComplete.Invoke(score); //Sent out Score and WaveTimer
            enemiesKilled = 0;
            StartCoroutine(StartWave());
        }
    }
}
