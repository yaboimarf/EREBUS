using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineTower : MonoBehaviour
{
    public float speedMultiplier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().SpeedMultiplyerDecrease(speedMultiplier);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().SpeedMultiplyerIncrease(speedMultiplier);
        }
    }
}
