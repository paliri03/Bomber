using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyModel enemyModel;
    [SerializeField] protected EnemyView enemyView;

    public abstract event Action<Enemy> OnDeath;

    public abstract void Init(IPathfinding pathfinding);
}
