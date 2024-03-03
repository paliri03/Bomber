using System;
using UnityEngine;

public abstract class EnemyModel : MonoBehaviour
{
    [SerializeField] protected float startHP;
    [SerializeField] protected float movementSpeed;

    public float MovementSpeed => movementSpeed;


    protected float currentHP;

    public abstract event Action<float> OnHPChanged;
    public abstract event Action OnDeath;
}
