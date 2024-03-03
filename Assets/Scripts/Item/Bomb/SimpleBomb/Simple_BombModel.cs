using UnityEngine;

[CreateAssetMenu(fileName = "SimpleBomb", menuName = "ScriptableObjects/BombModel/SimpleBomb")]
public class Simple_BombModel : BombModel
{
    [SerializeField] protected float collisionRadius;

    public float CollisionRadius => collisionRadius;
}

