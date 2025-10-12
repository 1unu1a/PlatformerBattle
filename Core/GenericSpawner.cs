using UnityEngine;

namespace Core
{
    public abstract class GenericSpawner<T> : MonoBehaviour where T : Component, IPoolObject
    {
        [Header("Spawner Settings")]
        [SerializeField] private T _prefab;
        [SerializeField] private int _initialCount = 10;
        [SerializeField] private float _spawnInterval = 2f;
        [SerializeField] private Transform _spawnParent;

        protected ObjectPool<T> Pool;
        private WaitForSeconds _wait;

        protected virtual void Awake()
        {
            Pool = new ObjectPool<T>();
            Pool.Init(_prefab, _initialCount, _spawnParent);
            _wait = new WaitForSeconds(_spawnInterval);
        }

        protected virtual void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private System.Collections.IEnumerator SpawnRoutine()
        {
            while (true)
            {
                Spawn();
                yield return _wait;
            }
        }

        protected abstract void Spawn();
    }
}