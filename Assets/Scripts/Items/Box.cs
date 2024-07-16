using UnityEngine;

[RequireComponent (typeof(Renderer))]

public class Box : MonoBehaviour
{
    private BombSpawner _bombSpawner;
    private ItemPool<Box> _pool;

    public void Initialize(ItemPool<Box> pool, BombSpawner bombSpawner)
    {
        GetComponent<Renderer>().material.color = Color.white;
        _bombSpawner = bombSpawner;
        _pool = pool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Platform>())
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
            _pool.Put(this);
            _bombSpawner.Spawn(transform.position);
        }
    }
}