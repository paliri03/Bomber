using System.Collections;
using UnityEngine;

/// <summary>
///  Простая бомба, взрывается через заданное время после создания.
/// </summary>
public class Timer_Bomb : Bomb
{
    private Timer_BombModel _bombModel;
    private Timer_BombView _bombView;

    public override void Init()
    {
        _bombModel = bombModel as Timer_BombModel;
        _bombView = bombView as Timer_BombView;

        StartCoroutine(DelayExplode());
    }

    public override void Explode()
    {
        _bombView.StartExplosionEffect(transform.position);

        foreach (var obj in GetDamagableObjects())
            obj.TakeDamage(_bombModel.Damage);

        Destroy(gameObject);
    }

    IEnumerator DelayExplode()
    {
        yield return new WaitForSeconds(_bombModel.ExplosionDelay);

        Explode();
    }
}
