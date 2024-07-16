using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected ItemPool<T> Pool;

    public abstract void Spawn(Vector3 position);
}