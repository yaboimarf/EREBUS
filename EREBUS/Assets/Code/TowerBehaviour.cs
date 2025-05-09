using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public Transform target;
    public Transform gun;
    public float rotateSpeed;
    // Use this for initialization
    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // face the target
        transform.LookAt(new Vector3 (target.position.x,transform.position.y, target.position.z));
        gun.LookAt(new Vector3(target.position.x,target.position.y, gun.position.z));
    }
}
