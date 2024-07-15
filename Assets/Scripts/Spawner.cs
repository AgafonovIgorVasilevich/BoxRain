using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private BoxPool _pool;

    [SerializeField] private float _lengthArea = 9;
    [SerializeField] private int _minCount = 1;
    [SerializeField] private int _maxCount = 5;
    [SerializeField] private float _tick = 0.5f;
    [SerializeField] private bool _isWork = true;

    private WaitForSeconds _delay;
    private Vector3 _spawnPoint;
    private int _spawnCount;

    private void Start()
    {
        _delay = new WaitForSeconds(_tick);
        _spawnPoint = transform.position;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isWork)
        {
            _spawnCount = Random.Range(_minCount, _maxCount);

            for (int i = 0; i < _spawnCount; i++)
            {
                _spawnPoint.x = Random.Range(-_lengthArea, _lengthArea);
                _spawnPoint.z = Random.Range(-_lengthArea, _lengthArea);
                _pool.Get(_spawnPoint).Initialize(_destroyer);
            }

            yield return _delay;
        }
    }
}