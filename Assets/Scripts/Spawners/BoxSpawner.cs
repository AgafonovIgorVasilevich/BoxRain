using System.Collections;
using UnityEngine;

public class BoxSpawner : Spawner<Box>
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private float _lengthArea = 9;
    [SerializeField] private float _tick = 0.5f;
    [SerializeField] private int _minCount = 1;
    [SerializeField] private int _maxCount = 5;
    [SerializeField] private bool _isWork = true;

    private WaitForSeconds _delay;
    private int _count;

    private void Start() => StartCoroutine(SpawnBoxes());

    public override void Spawn(Vector3 position)
    {
        Box box = Pool.Get(position);
        box.Destroyed += Unspawn;
    }

    private Vector3 GetRandomPointInArea()
    {
        Vector3 point = transform.position;
        point.x = Random.Range(-_lengthArea, _lengthArea);
        point.z = Random.Range(-_lengthArea, _lengthArea);

        return point;
    }

    private IEnumerator SpawnBoxes()
    {
        _delay = new WaitForSeconds(_tick);

        while (_isWork)
        {
            _count = Random.Range(_minCount, _maxCount);

            for (int i = 0; i < _count; i++)
                Spawn(GetRandomPointInArea());

            yield return _delay;
        }
    }

    protected override void Unspawn(Box instance)
    {
        Pool.Put(instance);
        instance.Destroyed -= Unspawn;
        _bombSpawner.Spawn(instance.transform.position);
    }
}