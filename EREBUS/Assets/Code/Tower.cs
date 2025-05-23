using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public GameObject core;
    public GameObject gun;
    public float turningSpeed;
    public float angleTurningAccuracy;
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject currentTarget;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float reloadTime;
    public float timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            UpdateTarget();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            currentTarget = null;
            UpdateTarget();
        }
    }
    private void UpdateTarget()
    {
        if(currentTarget != null)
        {
            return;
        }
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach(GameObject enemy in enemiesInRange)
        {
            if(enemy == null)
            {
                //enemiesInRange.Remove(enemy);
                return;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        if(closestEnemy != null)
        {
            currentTarget = closestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }
    private void Update()
    {
        foreach(GameObject deadEnemy in enemiesInRange)
        {
            if(deadEnemy == null)
            {
                enemiesInRange.Remove(deadEnemy);
            }
        }
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if(currentTarget != null)
        {
            Vector3 aimAt = new Vector3(currentTarget.transform.position.x, core.transform.position.y, currentTarget.transform.position.z);
            float distanceToTarget = Vector3.Distance(aimAt, gun.transform.position);

            Vector3 relativeTargetPosition = gun.transform.position + (gun.transform.forward * distanceToTarget);

            relativeTargetPosition = new Vector3(relativeTargetPosition.x, currentTarget.transform.position.y, relativeTargetPosition.z);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.LookRotation(relativeTargetPosition - gun.transform.position), Time.deltaTime * turningSpeed);
            core.transform.rotation = Quaternion.Slerp(core.transform.rotation, Quaternion.LookRotation(aimAt - core.transform.position), Time.deltaTime * turningSpeed);

            Vector3 directionToTarget = currentTarget.transform.position - gun.transform.position;

            if(Vector3.Angle(directionToTarget, gun.transform.forward) < angleTurningAccuracy)
            {
                if(timer <= 0)
                {
                    Fire();
                    timer = reloadTime;
                }
            }
        }
    }

    private void Fire()
    {        
        Instantiate(bulletPrefab, bulletSpawnPoint.position , bulletSpawnPoint.rotation);        
    }
}
