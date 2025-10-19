using System;
using UnityEngine;

namespace Platformer.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyChase : MonoBehaviour
    {
        public event Action OnAggro;
        public event Action OnLoseAggro;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                OnAggro?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                OnLoseAggro?.Invoke();
        }
    }
}