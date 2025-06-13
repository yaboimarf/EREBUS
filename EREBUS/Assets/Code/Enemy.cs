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
    public int fundsOnDeath;
    public ScoreBoard scoreBoard;
    public int health;
    public int damageToPlayer;
    public float baseSpeed;
    public float speedMultiplyer;
    public ParticleSystem deathExplosion;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.FindWithTag("CoinCounter").GetComponent<ScoreBoard>();
        endPoint = GameObject.FindWithTag("EndPoint");
        waveSpawner = GetComponentInParent<WaveSpawner>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = endPoint.transform.position;
        speedMultiplyer = 1f;
        agent.speed = baseSpeed * speedMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.3f)
        {
            EnemyReachedEnd();
        }
        if(health <= 0)
        {
            EnemyKillled();
        }
    }
    public void EnemyKillled()
    {
        deathExplosion.Play();
        scoreBoard.AddFunds(fundsOnDeath);
        Destroy(this.gameObject);
        waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
    }
    public void EnemyReachedEnd()
    {
        deathExplosion.Play();
        scoreBoard.RemoveHealth(damageToPlayer);
        Destroy(this.gameObject);
        waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
    }
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;        
    }
    public void SpeedMultiplyerDecrease(float reduction)
    {
        speedMultiplyer -= reduction;
        SpeedUpdate();
    }
    public void SpeedMultiplyerIncrease(float increase)
    {
        speedMultiplyer += increase;
        SpeedUpdate();
    }
    public void SpeedUpdate()
    {
        agent.speed = baseSpeed * speedMultiplyer;
    }
}
