using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Quick_EnemyView : EnemyView
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private IPathfinding pathfinding;

    public void InitMovement(Vector3 startPosition, float speed, IPathfinding pathfinding)
    {
        this.pathfinding = pathfinding;

        navMeshAgent.transform.position = startPosition; 
        navMeshAgent.speed = speed;
    }

    public override void Move()
    {
        var nextPosition = pathfinding.GetRandomPathPoint();
        navMeshAgent.SetDestination(nextPosition);

        StartCoroutine(MoveNext(nextPosition));
    }

    IEnumerator MoveNext(Vector3 firstDestination) 
    {
        var nextPostion = firstDestination;

        while(true)
        {
            if (Vector3.Distance(navMeshAgent.transform.position, nextPostion) < 1)
            {
                nextPostion = pathfinding.GetRandomPathPoint();
                navMeshAgent.SetDestination(nextPostion);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}

