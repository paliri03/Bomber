using System;
using UnityEngine;

public abstract class BombView : MonoBehaviour
{
    [SerializeField] protected ParticleSystem explodePSPrefab;

    public virtual void StartExplosionEffect(Vector3 position)
    {
        Instantiate(explodePSPrefab, position, Quaternion.identity);
    }
}

