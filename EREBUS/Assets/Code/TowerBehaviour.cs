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
    public List<Transform> enemylist = new List<Transform>();
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
        if (target == null)
        {
            target = enemylist[0];            
        }

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= targetRadius)
            {
                print("target in range");
            }
            else
            {
                //target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
                target = enemylist[0];
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            enemylist.Add(GameObject.FindWithTag("Enemy").GetComponent<Transform>());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            enemylist.Remove(GameObject.FindWithTag("Enemy").GetComponent<Transform>());
        }
    }
}
