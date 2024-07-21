using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private EffectSpawner _effectSpawner;

    public override void Spawn(Vector3 position)
    {
        Bomb bomb = Pool.Get(position);
        bomb.Destroyed += Unspawn;
    }

    protected override void Unspawn(Bomb instance)
    {
        Pool.Put(instance);
        instance.Destroyed -= Unspawn;
        _effectSpawner.Spawn(instance.transform.position);
    }
}