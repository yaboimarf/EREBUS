using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public TowerBehaviour towerBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towerBehaviour == null)
        {
            towerBehaviour = GameObject.FindWithTag("Tower").GetComponent<TowerBehaviour>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Tower") == true)
        {
            towerBehaviour.enemylist.Add(transform);
        }
        //transform.gameObject.tag = "Untagged";
        //Destroy(gameObject,0.1f);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Tower") == true)
        {
            towerBehaviour.enemylist.Remove(transform);
            Destroy(gameObject, 0.1f);
        }
    }
}
