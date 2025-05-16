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
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, enemySpawnDelay);
    }

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
}
