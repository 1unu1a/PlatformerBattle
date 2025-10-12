using UnityEngine;
using Platformer.Coins;

namespace Platformer.Player
{
    public class PlayerCollector : MonoBehaviour
    {
        private int _coins;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                _coins++;
                coin.Collect();
                Debug.Log($"Coins: {_coins}");
            }
        }
    }
}