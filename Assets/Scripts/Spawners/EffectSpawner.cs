using UnityEngine;

public class EffectSpawner : Spawner<Effect>
{
    public override void Spawn(Vector3 position) => Pool.Get(position).Initialize(Pool);
}