using UnityEngine;
using Core;

namespace Platformer.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))] 
    public class Enemy : MonoBehaviour, IPoolObject 
    { 
        [Header("Components")] 
        [SerializeField] private EnemyPatrol _patrol; 
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Init()
        {
            _patrol.BeginPatrol();
        }

        public void DeInit()
        {
            _rigidbody.linearVelocity = Vector2.zero; _patrol.StopPatrol();
        } 
    }
}