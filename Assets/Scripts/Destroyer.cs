using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _minLifeTime = 2;
    [SerializeField] private float _maxLifeTime = 5;
    [SerializeField] private BoxPool _pool;

    public void Destroy(Box box) => StartCoroutine(DelayDestroy(box));

    private IEnumerator DelayDestroy(Box box)
    {
        yield return new WaitForSeconds(Random.Range(_maxLifeTime, _minLifeTime));
        _pool.Put(box);
    }
}