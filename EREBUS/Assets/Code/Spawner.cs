using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> wayPoint;
    public float enemySpawnDelay;
    public int maxCount;
    private int count = 0;
    

    private void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().SetDestination(wayPoint);

        count++;
        if(count >= maxCount)
        {
            CancelInvoke();
        }
    }
    public void StartNextWave()
    {
        count = 0;
        InvokeRepeating("Spawn", 1, enemySpawnDelay);
    }
    public void StopSpawning()
    {
        CancelInvoke();
    }
}
