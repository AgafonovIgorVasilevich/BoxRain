using UnityEngine;

public class EffectSpawner : Spawner<Effect>
{
    public override void Spawn(Vector3 position)
    {
        Effect effect = Pool.Get(position);
        effect.Destroyed += Unspawn;
    }

    protected override void Unspawn(Effect instance)
    {
        instance.Destroyed -= Unspawn;
        Pool.Put(instance);
    }
}