using System;

public class Quick_EnemyModel : EnemyModel
{
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
