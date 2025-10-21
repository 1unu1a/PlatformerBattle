using UnityEngine;
using Core;
using Platformer.Player;

namespace Platformer.Items
{
    public class Medkit : PoolObject
    {
        [SerializeField] private int _healAmount = 25;
        [SerializeField] private float _rotationSpeed = 50f;

        private void Update()
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.Heal(_healAmount);
                gameObject.SetActive(false);
            }
        }
    }
}