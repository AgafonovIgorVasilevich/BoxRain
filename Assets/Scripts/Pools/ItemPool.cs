using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ItemPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _template;

    private Queue<T> _pool = new Queue<T>();
    private int _countInstance;

    public event Action<int> CountChanged;

    public T Get(Vector3 position)
    {
        T instance;

        if (_pool.Count == 0)
            instance = Instantiate(_template, transform);
        else
            instance = _pool.Dequeue();

        instance.transform.position = position;
        instance.gameObject.SetActive(true);
        _countInstance++;
        CountChanged?.Invoke(_countInstance);
        return instance;
    }

    public void Put(T instance)
    {
        instance.transform.parent = transform;
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
        _countInstance--;
        CountChanged?.Invoke(_countInstance);
    }
}