using UnityEngine;

namespace Platformer.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController2D : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 7f;

        [Header("Dependencies")]
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private GroundCheck _groundCheck;


        private bool _isGrounded;

        private void Update()
        {
            _isGrounded = _groundCheck.IsGrounded;
            
            _animator.SetFloat("Speed", Mathf.Abs(_input.Horizontal));
            
            if (_input.Horizontal != 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Sign(_input.Horizontal) * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            if (_input.JumpPressed && _isGrounded)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            Vector2 velocity = _rigidbody.linearVelocity;
            velocity.x = _input.Horizontal * _moveSpeed;
            _rigidbody.linearVelocity = velocity;
        }

        private void Jump()
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}