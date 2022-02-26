using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class PlayerModel
    {
        #region Fields

        public Vector2 Position;
        public Vector2 Destination;
        public PlayerState State;
        private int _hp;
        private readonly float _speed;
        private readonly int _maxHp;
        private readonly int _damageTaken;

        #endregion


        #region Properties

        public float GetSpeed => _speed;

        #endregion


        #region ClassLifeCycles

        public PlayerModel(float speed, int maxHp, int damageTaken)
        {
            _speed = speed;
            _maxHp = maxHp;
            _damageTaken = damageTaken;
        }

        #endregion


        #region Methods

        public void Initialize(Vector2 position)
        {
            Position = position;
            Destination = position;
            State = PlayerState.Idle;
            _hp = _maxHp;
        }

        public float GetNormalizedHP()
        {
            return (float)_hp / _maxHp;
        }

        public void TakeDamage()
        {
            _hp -= _damageTaken;
            if (_hp <= 0)
            {
                State = PlayerState.Dead;
            }
        }

        #endregion
    }
}
