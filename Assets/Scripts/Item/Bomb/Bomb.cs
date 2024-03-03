using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : Item
{
    [SerializeField] protected BombModel bombModel;
    [SerializeField] protected BombView bombView;

    public override Sprite InventoryIcon => bombModel.Icon;

    public abstract void Explode();

    protected List<IDamagable> GetDamagableObjects()
    {
        var overlapObjects = Physics.OverlapSphere(transform.position, bombModel.DamageRadius);

        var damagableObjects = new List<IDamagable>();

        foreach (var obj in overlapObjects)
        {
            Physics.Raycast(transform.position, (obj.transform.position - transform.position).normalized * bombModel.DamageRadius, out RaycastHit hit);

            if (obj.TryGetComponent(out IDamagable damagableObject) && hit.collider == obj)
                damagableObjects.Add(damagableObject);
        }

        return damagableObjects;
    }
}
