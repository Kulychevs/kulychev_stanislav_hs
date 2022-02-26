using System;
using UnityEngine;


namespace HotSiberiansTest
{
    [Serializable]
    public sealed class MapData
    {
        [SerializeField] private GameObject _basePrefab;
        [SerializeField] private GameObject _patrolPointPrefab;
        [SerializeField][Min(1)] private int _patrolPoints = 1;
        [SerializeField][Min(0.0f)][Tooltip("Min range between panrol points")]
        private float _minRange = 0.0f;

        public GameObject BasePrefab => _basePrefab;
        public GameObject PatrolPointPrefab => _patrolPointPrefab;
        public int PatrolPoints => _patrolPoints;
        public float MinRange => _minRange;
    }
}
