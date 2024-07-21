using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Renderer))]

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _minLifeTime = 2;
    [SerializeField] private float _maxLifeTime = 5;
    [SerializeField] private float _force = 500;
    [SerializeField] private float _radius = 5;

    private Color _color = Color.black;
    private Renderer _renderer;

    public event Action<Bomb> Destroyed;

    private void Awake() => _renderer = GetComponent<Renderer>();

    private void OnEnable() => StartCoroutine(DelayExplosion());

    private void Explosion()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collision in collisions)
            if (collision.TryGetComponent(out Rigidbody target))
                target.AddExplosionForce(_force, transform.position, _radius);
    }

    private IEnumerator DelayExplosion()
    {
        float lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        float timeLeft = lifeTime;

        while (timeLeft >= 0)
        {
            _color.a = timeLeft / lifeTime;
            _renderer.material.color = _color;
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        Destroyed?.Invoke(this);
        Explosion();
    }
}