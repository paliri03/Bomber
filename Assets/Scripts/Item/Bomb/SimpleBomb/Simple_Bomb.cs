/// <summary>
///  Простая бомба, взрывается сразу после коллизии.
/// </summary>
public class Simple_Bomb : Bomb
{
    private Simple_BombModel _bombModel;
    private Simple_BombView _bombView;

    public override void Init()
    {
        _bombModel = bombModel as Simple_BombModel;
        _bombView = bombView as Simple_BombView;

        _bombView.Init(_bombModel.CollisionRadius);

        _bombView.OnCollision += Explode;
    }

    public override void Explode()
    {
        _bombView.StartExplosionEffect(transform.position);

        foreach(var obj in GetDamagableObjects())
            obj.TakeDamage(_bombModel.Damage);

        Destroy(gameObject);
    }
}
