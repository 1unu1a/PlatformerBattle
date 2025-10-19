using UnityEngine;
using Core;

namespace Platformer.Coins
{
    public class Coin : PoolObject
    {
        [SerializeField] private float _rotationSpeed = 90f;

        private void Update()
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        public void Collect()
        {
            gameObject.SetActive(false);
        }
    }
}