using UnityEngine;
using Core;
using Platformer.Items;

namespace Platformer.Spawners
{
    public class MedkitSpawner : GenericSpawner<Medkit>
    {
        [SerializeField] private Transform[] _spawnPoints;

        protected override void Spawn()
        {
            if (_spawnPoints.Length == 0)
            {
                return;
            }

            Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Medkit medkit = Pool.Get();
            medkit.transform.position = point.position;
            medkit.Init(Pool);
        }
    }
}