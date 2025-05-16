using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private List<Transform> wayPoint;
    private NavMeshAgent agent;
    private int currentWayPointIndex = 0;
    private float agentStoppingDistance = 0.3f;
    private bool wayPointSet = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wayPointSet)
        {
            return;
        }
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
    public void SetDestination(List<Transform> wayPoint)
    {
        this.wayPoint = wayPoint;
        wayPointSet = true;
    }    
}
