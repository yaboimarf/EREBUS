using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float countDown;
    public GameObject spawnPoint;
    
    public Wave[] waves;
    public int currentWaveIndex = 0;
    private bool readyToCountDown;
    // Start is called before the first frame update
    void Start()
    {
        readyToCountDown = true;
        for(int i =0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(currentWaveIndex >= waves.Length)
        {
            Debug.Log("all clear");
            return;
        }
        if(readyToCountDown == true)
        {
            countDown -= Time.deltaTime;
        }
        if (countDown <= 0)
        {
            readyToCountDown = false;
            countDown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }
        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
                enemy.transform.SetParent(spawnPoint.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }        
    }
}
[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
}
