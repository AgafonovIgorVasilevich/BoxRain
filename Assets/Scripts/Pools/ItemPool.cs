using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ItemPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _template;

    private Queue<T> _pool = new Queue<T>();
    private int _countInstance;
    private int _countActive;

    public event Action<int, int> CountChanged;

    public T Get(Vector3 position)
    {
        T instance;

        if (_pool.Count == 0)
        {
            instance = Instantiate(_template, transform);
            _countInstance++;
        }
        else
        {
            instance = _pool.Dequeue();
        }

        _countActive++;
        instance.transform.position = position;
        instance.gameObject.SetActive(true);
        CountChanged?.Invoke(_countInstance, _countActive);
        return instance;
    }

    public void Put(T instance)
    {
        instance.transform.parent = transform;
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
        _countActive--;
        CountChanged?.Invoke(_countInstance, _countActive);
    }
}