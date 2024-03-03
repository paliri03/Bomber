using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshPathfinding : MonoBehaviour, IPathfinding
{
    private NavMeshSurface navMeshSurface;

    private Vector3 surfaceExtents;
    private Vector3 surfaceCenter;

    private System.Random random;

    public void Init()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();

        surfaceExtents = navMeshSurface.navMeshData.sourceBounds.extents;
        surfaceCenter = navMeshSurface.navMeshData.sourceBounds.center;

        random = new System.Random();
    }

    public Vector3 GetRandomPathPoint()
    {
        NavMeshHit hit;

        while (!NavMesh.SamplePosition(GetRandomPointInBounds(), out hit, 1f, NavMesh.AllAreas))
            continue;

        return hit.position;
    }

    private Vector3 GetRandomPointInBounds()
    {
        var newPoint = new Vector3(
            surfaceCenter.x + random.Next((int)-surfaceExtents.x, (int)surfaceExtents.x),
            surfaceCenter.y,
            surfaceCenter.z + random.Next((int)-surfaceExtents.z, (int)surfaceExtents.z)
            );

        return newPoint;
    }
}
