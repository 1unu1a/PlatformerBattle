using UnityEngine;
using Core;
using Platformer.Enemies;

namespace Platformer.Spawners
{
    public class EnemySpawner : GenericSpawner<Enemy>
    {
        [SerializeField] private Transform[] _spawnPoints;

        protected override void Spawn()
        {
            if (_spawnPoints.Length == 0)
            {
                return;
            }

            Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Enemy enemy = Pool.Get();
            enemy.transform.position = point.position;
        }
    }
}