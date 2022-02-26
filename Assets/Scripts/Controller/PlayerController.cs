using System;


namespace HotSiberiansTest
{
    public sealed class PlayerController : IExecute, IInitalize, IClear
    {
        #region Fields

        public Action<float> OnHPChanged = delegate { };

        private readonly IMapInfo _mapInfo;
        private readonly UnitMotor _motor;
        private readonly PlayerModel _playerModel;
        private readonly PlayerView _playerView;

        #endregion


        #region ClassLifeCycles

        public PlayerController(PlayerData data, IMapInfo mapInfo)
        {
            _mapInfo = mapInfo;
            var creator = new PlayerCreator(data.Prefab);
            _motor = new UnitMotor();
            _playerModel = new PlayerModel(data.Speed, data.MaxHp, data.DamageTakenByClick);
            _playerView = creator.GetPlayer(_mapInfo.GetBasePosition());
            _playerView.OnClick += TakeDamage;
        }

        #endregion


        #region Methods

        public void Patrol()
        {
            if (_playerModel.State == PlayerState.Dead) return;

            _playerModel.Destination = _mapInfo.GetRandomPosition();
            _playerModel.State = PlayerState.InPatrol;
            _playerView.PlayIdleAnimation(false);
        }

        public void Idle()
        {
            if (_playerModel.State == PlayerState.Dead) return;

            _playerModel.State = PlayerState.Idle;
            _playerView.PlayIdleAnimation(true);
        }

        public void ToBase()
        {
            if (_playerModel.State == PlayerState.Dead) return;

            _playerModel.Destination = _mapInfo.GetBasePosition();
            _playerModel.State = PlayerState.ToBase;
            _playerView.PlayIdleAnimation(false);
        }

        public void TakeDamage()
        {
            _playerModel.TakeDamage();
            OnHPChanged.Invoke(_playerModel.GetNormalizedHP());
            if (_playerModel.State == PlayerState.Dead)
                _playerView.PlayIdleAnimation(false);
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            if (_playerModel.State == PlayerState.InPatrol || _playerModel.State == PlayerState.ToBase)
            {
                if (!_motor.Move(_playerModel, _playerView))
                {
                    if (_playerModel.State == PlayerState.InPatrol)
                        _playerModel.Destination = _mapInfo.GetRandomPosition();
                    else
                        Idle();
                }
            }
        }

        #endregion


        #region IInitialize

        public void Initialize()
        {
            _playerModel.Initialize(_mapInfo.GetBasePosition());
            Idle();
            OnHPChanged.Invoke(_playerModel.GetNormalizedHP());
            _playerView.SetPosition(_playerModel.Position);
            _playerView.SetActive(true);
        }

        #endregion


        #region IClear

        public void Clear()
        {
            _playerModel.State = PlayerState.Dead;
            _playerView.SetActive(false);
        }

        #endregion
    }
}
