using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _minLifeTime = 2;
    [SerializeField] private float _maxLifeTime = 5;
    [SerializeField] private float _force = 500;
    [SerializeField] private float _radius = 5;

    private EffectSpawner _effectSpawner;
    private Color _color = Color.black;
    private ItemPool<Bomb> _pool;
    private Renderer _renderer;

    private void Awake() => _renderer = GetComponent<Renderer>();

    public void Initialize(ItemPool<Bomb> pool, EffectSpawner effectSpawner)
    {
        _effectSpawner = effectSpawner;
        _pool = pool;
        StartCoroutine(Explosion());
    }

    private List<Rigidbody> GetTargets()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, _radius);
        List<Rigidbody> targets = new List<Rigidbody>();

        foreach (Collider collider in collisions)
            if (collider.TryGetComponent(out Rigidbody rigidbody))
                targets.Add(rigidbody);

        return targets;
    }

    private IEnumerator Explosion()
    {
        float lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
        float timeLeft = lifeTime;

        while (timeLeft >= 0)
        {
            _color.a = timeLeft / lifeTime;
            _renderer.material.color = _color;
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        _pool.Put(this);
        _effectSpawner.Spawn(transform.position);

        foreach (Rigidbody target in GetTargets())
            target.AddExplosionForce(_force, transform.position, _radius);
    }
}