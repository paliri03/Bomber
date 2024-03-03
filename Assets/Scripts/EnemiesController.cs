using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private List<EnemySet> enemiesSets;

    private readonly List<Enemy> enemiesList = new();
    private IPathfinding pathfinding;

    [Inject] public void Init(IPathfinding pathfinding)
    {
        this.pathfinding = pathfinding;
    }
    
    public void SpawnEnemies()
    {
        foreach(var enemySet in enemiesSets)
        {
            for(int i = 0; i < enemySet.enemyNumber; i++)
            {
                Enemy enemy = Instantiate(enemySet.enemyPrefab, transform);
                enemy.Init(pathfinding);
                enemy.OnDeath += EnemyDeathEvent;

                enemiesList.Add(enemy);
            }
        }
    }

    private void EnemyDeathEvent(Enemy obj)
    {
        enemiesList.Remove(obj);

        if (enemiesList.Count == 0)
            GameState.EndGame();
    }
}