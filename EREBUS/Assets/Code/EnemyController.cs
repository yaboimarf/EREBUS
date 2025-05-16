using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public List<Transform> wayPoint;
    private NavMeshAgent agent;
    private int currentWayPointIndex = 0;
    private float agentStoppingDistance = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if(wayPoint.Count == 0)
        {
            Debug.Log("There are no waypoints");
            return;
        }
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoint[currentWayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance <= agentStoppingDistance)
        {
            if(currentWayPointIndex == wayPoint.Count - 1)
            {
                Destroy(this.gameObject, 0.1f);
            }
            else
            {
                currentWayPointIndex++;
                agent.SetDestination(wayPoint[currentWayPointIndex].position);
            }
        }
    }
}
