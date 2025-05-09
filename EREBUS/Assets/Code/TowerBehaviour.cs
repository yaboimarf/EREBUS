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
    public List<int> enemies = new List<int>();
    public RaycastHit range;
    public float rangeMax;
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
        //Vector3 startPos = transform.position;
        //Collider[] colliders = Physics.OverlapSphere(startPos, targetRadius);
        //if (colliders != null)
        //{
        //    target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        //}

        if (target != GameObject.FindWithTag("Enemy").GetComponent<Transform>())
        {
            target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();                                         
        }
    }
}
