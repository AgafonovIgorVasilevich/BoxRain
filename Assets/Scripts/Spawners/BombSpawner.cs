using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private EffectSpawner _effectSpawner;

    public override void Spawn(Vector3 position) => Pool.Get(position).Initialize(Pool, _effectSpawner);
}