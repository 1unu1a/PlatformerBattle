using UnityEngine;

namespace Platformer.Enemies
{
    public class EnemyPatrol : MonoBehaviour
    {
        [Header("Patrol Settings")]
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;
        [SerializeField] private float _speed = 2f;

        private bool _movingRight = true;
        private Vector3 _target;
        private bool _active;

        public void BeginPatrol()
        {
            /*if (_leftPoint == null || _rightPoint == null)
            {
                Debug.LogWarning("EnemyPatrol не заданы");
                return;
            }*/

            _active = true;
            _movingRight = true;
            _target = _rightPoint.position;
        }

        public void StopPatrol()
        {
            _active = false;
        }

        private void Update()
        {

            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target) < 0.05f)
            {
                _movingRight = !_movingRight;
                _target = _movingRight ? _rightPoint.position : _leftPoint.position;

                Vector3 scale = transform.localScale;
                scale.x = _movingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }
}