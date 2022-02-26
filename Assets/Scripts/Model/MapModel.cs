using System.Collections.Generic;
using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class MapModel
    {
        #region Fields

        private readonly List<MapObjectModel> _patrolPoints;
        private MapObjectModel _base;
        private readonly float _minRange;
        private readonly int _pointsAmount;

        #endregion


        #region Properties

        public Vector2 GetBasePosition => _base.Position;
        public float GetMinRange => _minRange;
        public int GetPointsAmount => _pointsAmount;

        #endregion


        #region ClassLifeCycles

        public MapModel(int patrolPoints, float minRange)
        {
            _patrolPoints = new List<MapObjectModel>();
            _minRange = minRange;
            _pointsAmount = patrolPoints;
        }

        #endregion


        #region Methods

        public void Initialize(List<MapObjectModel> points, MapObjectModel baseObject)
        {
            _patrolPoints.AddRange(points);
            _base = baseObject;
        }

        public Vector2 GetRandomPatrolPosition()
        {
            var index = Random.Range(0, _patrolPoints.Count);

            return _patrolPoints[index].Position;
        }

        public void Clear()
        {
            foreach (var point in _patrolPoints)
            {
                Object.Destroy(point.GameObject);
            }
            _patrolPoints.Clear();
            Object.Destroy(_base.GameObject);
        }

        #endregion
    }
}
