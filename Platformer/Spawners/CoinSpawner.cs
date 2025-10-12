using UnityEngine;
using Core;
using Platformer.Coins;

namespace Platformer.Spawners
{
    public class CoinSpawner : GenericSpawner<Coin>
    {
        [SerializeField] private Transform[] _spawnPoints;

        protected override void Spawn()
        {
            if (_spawnPoints.Length == 0)
            {
                return;
            }

            Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Coin coin = Pool.Get();
            coin.transform.position = point.position;
        }
    }
}