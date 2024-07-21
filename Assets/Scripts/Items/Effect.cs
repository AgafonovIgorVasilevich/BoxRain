using UnityEngine;
using System;

public class Effect : MonoBehaviour
{
    public event Action<Effect> Destroyed;

    private void OnDisable() => Destroyed?.Invoke(this);
}