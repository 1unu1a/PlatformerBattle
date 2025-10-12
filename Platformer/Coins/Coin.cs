using UnityEngine;
using Core;

namespace Platformer.Coins
{
    public class Coin : MonoBehaviour, IPoolObject
    {
        [SerializeField] private float _rotationSpeed = 90f;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        public void Init() { }

        public void DeInit() { }

        public void Collect()
        {
            gameObject.SetActive(false);
        }
    }
}