using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public TowerBehaviour towerBehaviour;
    public List<Transform> inRangeTower = new List<Transform>();
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0f)
        {
            transform.gameObject.tag = "Untagged";
            Destroy(gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.Equals("Tower") == true)
        //{
        //    inRangeTower.Add(transform);
        //    towerBehaviour.enemylist.Add(transform);
        //}
        //transform.gameObject.tag = "Untagged";
        //Destroy(gameObject,0.1f);
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag.Equals("Tower") == true)
        //{
        //    inRangeTower.Remove(transform);
        //    towerBehaviour.enemylist.Remove(transform);
        //    //Destroy(gameObject, 0.1f);
        //}
    }
}
