using System.Collections.Generic;
using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class MapObjectsCreator
    {
        #region Fields

        private const string POINTS_PARENT_NAME = "PatrolPoints";
        private const int MAX_TRIES = 10000;
        private const float BORDER_OFFSET = 0.15f;
        private const float LEFT_BORDER = -2.0f + BORDER_OFFSET;
        private const float RIGHT_BORDER = 2.0f - BORDER_OFFSET;
        private const float TOP_BORDER = 4.5f - BORDER_OFFSET;
        private const float BOTTOM_BORDER = -2.5f + BORDER_OFFSET;

        private readonly GameObject _basePrefab;
        private readonly GameObject _patrolPointPrefab;
        private readonly Transform _pointsParent;

        #endregion


        #region ClassLifeCycles

        public MapObjectsCreator(GameObject basePrefab, GameObject patrolPointPrefab)
        {
            _basePrefab = basePrefab;
            _patrolPointPrefab = patrolPointPrefab;
            _pointsParent = new GameObject(POINTS_PARENT_NAME).transform;
        }

        #endregion


        #region Methods

        public MapObjectModel CreateBase()
        {
            var pos = GetRandomPosition();
            var obj = new MapObjectModel
            {
                Position = pos,
                GameObject = Object.Instantiate(_basePrefab, pos, Quaternion.identity)
            };

            return obj;
        }

        public List<MapObjectModel> CreatePatrolPoints(int amount, float minRange)
        {
            var points = new List<MapObjectModel>
            {
                Capacity = amount
            };

            Vector2 pos;
            int tries;
            for (int i = 0; i < amount; i++)
            {
                tries = 0;
                do
                {
                    pos = GetRandomPosition();
                    tries++;
                    
                } while (!CheckPatrolPointPositionAvailability(pos, points, minRange) && tries <= MAX_TRIES);

                var point = new MapObjectModel
                {
                    GameObject = Object.Instantiate(_patrolPointPrefab, pos, Quaternion.identity, _pointsParent),
                    Position = pos
                };
                points.Add(point);
                if (tries > MAX_TRIES)
                {
                    Debug.LogError($"Can't find suitable position for {i} point in {MAX_TRIES} tries");
                    break;
                }
            }

            return points;
        }

        private Vector2 GetRandomPosition()
        {
            var x = Random.Range(LEFT_BORDER, RIGHT_BORDER);
            var y = Random.Range(BOTTOM_BORDER, TOP_BORDER);

            return new Vector2(x, y);
        }

        private bool CheckPatrolPointPositionAvailability(Vector2 position, List<MapObjectModel> patrolPoints, float minRange)
        {
            foreach (var point in patrolPoints)
            {
                if (!CheckRange(position - point.Position, minRange))
                    return false;
            }

            return true;
        }

        private bool CheckRange(Vector2 vector, float minRange)
        {
            if (vector.sqrMagnitude < minRange * minRange)
                return false;
            return true;
        }

        #endregion
    }
}
