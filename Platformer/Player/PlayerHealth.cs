using UnityEngine;
using Core;

namespace Platformer.Player
{
    [RequireComponent(typeof(Health))]
    public class PlayerHealth : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.OnDied.AddListener(OnDied);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public void Heal(int amount)
        {
            _health.Heal(amount);
        }

        private void OnDied()
        {
            Debug.Log("Player died");
        }
    }
}