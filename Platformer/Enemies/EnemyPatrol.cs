using UnityEngine;

namespace Platformer.Enemies
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _speed = 2f;

        private int _targetIndex = 0;
        private bool _isPatrolling = true;

        private void Start()
        {
            if (_points == null || _points.Length == 0)
            {
                Debug.LogWarning($"{name}: Не заданы точки патруля");
                enabled = false;
                return;
            }

            transform.position = _points[0].position;
            _targetIndex = 1 % _points.Length;
        }

        private void Update()
        {
            if (!_isPatrolling || _points.Length < 2) return;

            Transform target = _points[_targetIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.05f)
            {
                _targetIndex = (_targetIndex + 1) % _points.Length;
                FlipDirection();
            }
        }

        private void FlipDirection()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        public void StopPatrol() => _isPatrolling = false;
        public void BeginPatrol() => _isPatrolling = true;
    }
}