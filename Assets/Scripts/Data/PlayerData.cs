using System;
using UnityEngine;


namespace HotSiberiansTest
{
    [Serializable]
    public sealed class PlayerData
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField][Min(1)] private int _maxHp = 1;
        [SerializeField][Min(1)] private int _damageTakenByClick = 1;
        [SerializeField][Min(0.1f)] private float _speed = 0.1f;

        public PlayerView Prefab => _playerPrefab;
        public int MaxHp => _maxHp;
        public int DamageTakenByClick => _damageTakenByClick;
        public float Speed => _speed;
    }
}
