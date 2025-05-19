using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int maxWave;
    private int currentWave = 0;
    public Spawner spawner;
    private bool isSpawning = false;
    private int enemiesRemaining = 0;
    private float timer = 0f;
    public float waveSpawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            timer = 0f;
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if(currentWave >= maxWave)
                {
                    StopSpawning();
                }
                else
                {
                    StartNextWave();
                }
            }
        }
    }
    public void EnemyDestroyed()
    {
        enemiesRemaining--;
        if(enemiesRemaining == 0)
        {
            isSpawning = false;
            timer = waveSpawnInterval;
        }
    }
    private void StartNextWave()
    {
        currentWave++;
        spawner.StartNextWave();
        enemiesRemaining = spawner.maxCount;
        isSpawning = true;
    }
    private void StopSpawning()
    {
        spawner.StopSpawning();
        isSpawning = false;
    }
}
