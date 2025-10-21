using UnityEngine;

namespace Platformer.Enemies
{
    public class EnemyChase : MonoBehaviour
    {
        [SerializeField] private float _speed = 2.5f;
        [SerializeField] private float _chaseDistance = 6f;
        [SerializeField] private float _stopDistance = 1f;

        private Transform _player;
        private EnemyPatrol _patrol;
        private bool _isChasing;

        private void Awake()
        {
            _patrol = GetComponent<EnemyPatrol>();
        }

        public void SetPlayer(Transform player)
        {
            _player = player;
        }

        private void Update()
        {
            if (_player == null)
            {
                return;
            }

            float distance = Vector2.Distance(transform.position, _player.position);

            if (distance < _chaseDistance)
            {
                if (!_isChasing)
                {
                    _isChasing = true;
                    _patrol.StopPatrol();
                }

                if (distance > _stopDistance)
                {
                    Vector3 direction = (_player.position - transform.position).normalized;
                    transform.position += direction * _speed * Time.deltaTime;
                    
                    Vector3 scale = transform.localScale;
                    scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
            }
            else if (_isChasing)
            {
                _isChasing = false;
                _patrol.BeginPatrol();
            }
        }
    }
}