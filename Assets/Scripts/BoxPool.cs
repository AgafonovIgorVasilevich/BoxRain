using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    [SerializeField] private Box _box;

    private Queue<Box> _pool = new Queue<Box>();

    public Box Get(Vector3 position)
    {
        Box instance;

        if (_pool.Count == 0)
            instance = Instantiate(_box, transform);
        else
            instance = _pool.Dequeue();

        instance.transform.position = position;
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void Put(Box instance)
    {
        instance.transform.parent = transform;
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
    }
}