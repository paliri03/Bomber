using UnityEngine;

public abstract class BombModel : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] protected float damage;
    [SerializeField] protected float damageRadius;

    [Header("Inventory Info")]
    [SerializeField] protected Sprite icon;

    public float DamageRadius => damageRadius;

    public float Damage => damage;

    public Sprite Icon => icon;
}

