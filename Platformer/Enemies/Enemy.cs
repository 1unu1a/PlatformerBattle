using UnityEngine;
using UnityEngine.Events;
using Core;
using Platformer.Player;

namespace Platformer.Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour, IPoolObject
    {
        [SerializeField] private EnemyPatrol _patrol;
        [SerializeField] private EnemyChase _chase;
        [SerializeField] private int _damage = 20;
        [SerializeField] private float _attackCooldown = 1f;

        public UnityEvent OnPlayerAttacked;

        private Health _health;
        private PlayerHealth _playerHealth;
        private float _lastAttackTime;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.OnDied.AddListener(OnDied);
            
            OnPlayerAttacked.AddListener(() =>
            {
                Debug.Log($"{name} attacked");
            });
        }

        public void Init()
        {
            _health.ResetHealth();
            _patrol.BeginPatrol();
        }

        public void DeInit()
        {
            _patrol.StopPatrol();
        }

        public void SetPlayer(Transform player)
        {
            if (player.TryGetComponent(out PlayerHealth ph))
                _playerHealth = ph;

            _chase.SetPlayer(player);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (Time.time - _lastAttackTime >= _attackCooldown)
            {
                _lastAttackTime = Time.time;
                Debug.Log($"{name} attacked player");

                if (other.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.TakeDamage(_damage);
                }
            }
        }


        private void OnDied()
        {
            gameObject.SetActive(false);
        }
    }
}
