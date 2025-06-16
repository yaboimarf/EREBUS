using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineTower : MonoBehaviour
{
    public float speedMultiplier;
    public GameObject currentTarget;
    public int killNumber;
    public int killNumberRange;
    public Vector3 jammerRotate;
    public float jammerRotateSpeed;

    public void Update()
    {
        jammerRotate.y = jammerRotateSpeed * Time.deltaTime;
        transform.Rotate(jammerRotate);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().SpeedMultiplyerDecrease(speedMultiplier);
            currentTarget = other.gameObject;
            killNumber = Random.Range(0, killNumberRange);
            if(killNumber == 1)
            {
                currentTarget.GetComponent<Enemy>().TakeDamage(int.MaxValue);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().SpeedMultiplyerIncrease(speedMultiplier);
            currentTarget = null;
        }
    }
}
