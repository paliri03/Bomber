using System;

/// <summary>
///  Простой враг, передвигается к точкам, которые каждый раз генерируются случайно.
/// </summary>
public class Quick_Enemy : Enemy, IDamagable
{
    private Quick_EnemyModel _quickEnemyModel;
    private Quick_EnemyView _quickEnemyView;

    public override event Action<Enemy> OnDeath;

    public override void Init(IPathfinding pathfinding)
    {
        _quickEnemyModel = enemyModel as Quick_EnemyModel;
        _quickEnemyView = enemyView as Quick_EnemyView;

        _quickEnemyModel.OnDeath += DeathEvent;

        InitView(pathfinding);
    }

    public void TakeDamage(float damage)
    {
        _quickEnemyModel.TakeDamage(damage);
    }

    private void DeathEvent()
    {
        OnDeath?.Invoke(this);

        Destroy(gameObject);
    }

    private void InitView(IPathfinding pathfinding)
    {
        var startPosition = pathfinding.GetRandomPathPoint();

        _quickEnemyView.InitMovement(startPosition, _quickEnemyModel.MovementSpeed, pathfinding);

        _quickEnemyView.Move();
    }
}
