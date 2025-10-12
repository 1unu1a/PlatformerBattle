using UnityEngine;

namespace Platformer.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public bool JumpPressed { get; private set; }

        private void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            JumpPressed = Input.GetButtonDown("Jump");
        }
    }
}