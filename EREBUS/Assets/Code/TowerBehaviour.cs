using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public Transform target;
    public Transform gun;
    public float targetRadius;
    public Array[] enemylist;
    // Use this for initialization
    void Start()
    {
        TargetingAI();
    }

    // Update is called once per frame
    void Update()
    {
        TurretRotation();
        TargetingAI();
    }
    private void TurretRotation()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);

        Vector3 gundir = target.position - gun.position;
        gun.rotation = Quaternion.LookRotation(gundir);
    }
    private void TargetingAI()
    {
        if (target != GameObject.FindWithTag("Enemy").GetComponent<Transform>())
        {
            target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();            
        }

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= targetRadius)
            {
                print("target in range");
            }
            else
            {
                target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
                print("out of range");
            }
        }
    }
}
