using UnityEngine;


namespace HotSiberiansTest
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Data/" + nameof(GameSettings), order = 1)]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private MapData _mapData;

        public MapData MapData => _mapData;
        public PlayerData PlayerData => _playerData;
    }
}
