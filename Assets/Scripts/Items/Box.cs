using UnityEngine;
using System;

[RequireComponent(typeof(Renderer))]

public class Box : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Box> Destroyed;

    private void Awake() => _renderer = GetComponent<Renderer>();

    private void OnEnable() => _renderer.material.color = Color.white;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Platform>())
            Destroyed?.Invoke(this);
    }
}