using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPool<T> where T : Component, IPoolObject
    {
        private readonly Queue<T> _pool = new();
        private T _prefab;
        private Transform _parent;

        public void Init(T prefab, int count, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < count; i++)
            {
                T obj = Object.Instantiate(_prefab, _parent);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : Object.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(true);
            obj.Init();
            return obj;
        }

        public void Return(T obj)
        {
            obj.DeInit();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}