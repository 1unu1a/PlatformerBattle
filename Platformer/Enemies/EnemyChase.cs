using UnityEngine;

namespace Platformer.Enemies
{
    [RequireComponent(typeof(EnemyPatrol))]
    public class EnemyChase : MonoBehaviour
    {
        [Header("Chase Settings")]
        [SerializeField] private float _chaseRange = 5f;
        [SerializeField] private float _chaseSpeed = 3f;
        [SerializeField] private Transform _target;
        [SerializeField] private EnemyPatrol _patrol;

        private bool _isChasing;

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            float distance = Vector2.Distance(transform.position, _target.position);

            if (distance < _chaseRange && !_isChasing)
            {
                StartChase();
            }
            else if (distance >= _chaseRange && _isChasing)
            {
                StopChase();
            }

            if (_isChasing)
            {
                Chase();
            }
        }

        private void StartChase()
        {
            _isChasing = true;
            _patrol.StopPatrol();
        }

        private void StopChase()
        {
            _isChasing = false;
            _patrol.BeginPatrol();
        }

        private void Chase()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.position += direction * (_chaseSpeed * Time.deltaTime);
            
            Vector3 scale = transform.localScale;
            scale.x = direction.x >= 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}