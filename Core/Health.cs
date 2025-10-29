using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        public UnityEvent OnDied;
        public UnityEvent<int> OnDamaged;
        public UnityEvent<int> OnHealed;

        public int Current => _currentHealth;
        public int Max => _maxHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (_currentHealth <= 0)
            {
                return;
            }

            if (amount < 0)
            {
                return;
            }

            _currentHealth = Mathf.Max(0, _currentHealth - amount);
            OnDamaged?.Invoke(amount);

            if (_currentHealth == 0)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
            OnHealed?.Invoke(amount);
        }

        private void Die()
        {
            _currentHealth = 0;
            OnDied?.Invoke();
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }
    }
}