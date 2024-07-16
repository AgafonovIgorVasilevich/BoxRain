using UnityEngine;

public class Effect : MonoBehaviour
{
    private ItemPool<Effect> _pool;

    private void OnDisable() => _pool.Put(this);

    public void Initialize(ItemPool<Effect> pool) => _pool = pool;
}