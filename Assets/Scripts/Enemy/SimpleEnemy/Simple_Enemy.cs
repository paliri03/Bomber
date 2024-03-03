using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Простой враг, передвигается между несколькими заданными точками.
/// </summary>
public class Simple_Enemy : Enemy, IDamagable
{
    private Simple_EnemyModel _simpleEnemyModel;
    private Simple_EnemyView _simpleEnemyView;

    public override event Action<Enemy> OnDeath;

    public override void Init(IPathfinding pathfinding)
    {
        _simpleEnemyModel = enemyModel as Simple_EnemyModel;
        _simpleEnemyView = enemyView as Simple_EnemyView;

        _simpleEnemyModel.OnDeath += DeathEvent;

        InitView(pathfinding);
    }

    public void TakeDamage(float damage)
    {
        _simpleEnemyModel.TakeDamage(damage);
    }

    private void DeathEvent()
    {
        OnDeath?.Invoke(this);

        Destroy(gameObject);
    }

    private void InitView(IPathfinding pathfinding)
    {
        var startPosition = pathfinding.GetRandomPathPoint();

        List<Vector3> pathPoints = new();
        for (int i = 0; i < _simpleEnemyModel.PathPointsCount; i++)
            pathPoints.Add(pathfinding.GetRandomPathPoint());

        _simpleEnemyView.InitMovement(startPosition, _simpleEnemyModel.MovementSpeed, pathPoints);

        _simpleEnemyView.Move();
    }
}
