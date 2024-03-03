using UnityEngine;

[CreateAssetMenu(fileName = "TimerBomb", menuName = "ScriptableObjects/BombModel/TimerBomb")]
public class Timer_BombModel : BombModel
{
    [SerializeField] private float explosionDelay;

    public float ExplosionDelay => explosionDelay;
}

