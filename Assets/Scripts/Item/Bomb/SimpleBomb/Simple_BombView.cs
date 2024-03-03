using System;
using UnityEngine;

public class Simple_BombView : BombView
{
    [SerializeField] protected SphereCollider collisionCollider;

    public event Action OnCollision;
    public void Init(float collisionRadius)
    {
        collisionCollider.radius = collisionRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;

        OnCollision?.Invoke();
    }
}

