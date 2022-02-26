using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class MapController : IMapInfo, IInitalize, IClear
    {
        #region Fields

        private readonly MapObjectsCreator _creator;
        private readonly MapModel _model;

        #endregion


        #region ClassLyfeCycles

        public MapController(MapData data)
        {
            _creator = new MapObjectsCreator(data.BasePrefab, data.PatrolPointPrefab);
            _model = new MapModel(data.PatrolPoints, data.MinRange);
        }

        #endregion


        #region IMapInfo

        public Vector2 GetRandomPosition()
        {
            return _model.GetRandomPatrolPosition();
        }

        public Vector2 GetBasePosition()
        {
            return _model.GetBasePosition;
        }

        #endregion


        #region IInitialize

        public void Initialize()
        {
            var baseObject = _creator.CreateBase();
            var points = _creator.CreatePatrolPoints(_model.GetPointsAmount, _model.GetMinRange);

            _model.Initialize(points, baseObject);
        }

        #endregion


        #region IClear

        public void Clear()
        {
            _model.Clear();
        }

        #endregion
    }
}
