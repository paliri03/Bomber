using System;
using UnityEngine;

public class Simple_EnemyModel : EnemyModel
{
    [SerializeField, Min(2)] private int pathPointsCount; 

    public int PathPointsCount => pathPointsCount;

    public override event Action OnDeath;
    public override event Action<float> OnHPChanged;

    public void Init()
    {
        currentHP = startHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
            OnDeath?.Invoke();
    }
}
