using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class PlayerCreator
    {
        private readonly PlayerView _prefab;

        public PlayerCreator(PlayerView prefab)
        {
            _prefab = prefab;
        }

        public PlayerView GetPlayer(Vector2 position)
        {
            return Object.Instantiate<PlayerView>(_prefab, position, Quaternion.identity);
        }
    }
}
