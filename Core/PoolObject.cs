using UnityEngine;

namespace Core
{
    public abstract class PoolObject : MonoBehaviour, IPoolObject
    {
        public virtual void Init() { }
        public virtual void DeInit() { }
    }
}