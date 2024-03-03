using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Simple_EnemyView : EnemyView
{
    [SerializeField] private NavMeshAgent navMeshAgent;   

    private List<Vector3> pathPoints;

    public void InitMovement(Vector3 startPosition, float speed, List<Vector3> pathPoints)
    {
        navMeshAgent.transform.position = startPosition; 
        navMeshAgent.speed = speed;
        this.pathPoints = pathPoints;
    }

    public override void Move()
    {
        navMeshAgent.SetDestination(pathPoints[0]);

        StartCoroutine(MoveNext());
    }

    IEnumerator MoveNext() 
    {
        int i = 0;
        while(true)
        {
            if (Vector3.Distance(navMeshAgent.transform.position, pathPoints[i]) < 1)
            {
                navMeshAgent.SetDestination(pathPoints[i + 1]);
                i++;
                i %= pathPoints.Count - 1;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}

