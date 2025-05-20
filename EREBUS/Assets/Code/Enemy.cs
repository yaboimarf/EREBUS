using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private WaveSpawner waveSpawner;
    public GameObject endPoint;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameObject.FindWithTag("EndPoint");
        waveSpawner = GetComponentInParent<WaveSpawner>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = endPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.3f)
        {
            EnemyDeath();
        }
    }
    public void EnemyDeath()
    {
        Destroy(this.gameObject);
        waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
    }
}
