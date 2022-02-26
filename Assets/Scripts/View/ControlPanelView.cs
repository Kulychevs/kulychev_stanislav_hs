using System;
using UnityEngine;
using UnityEngine.UI;


namespace HotSiberiansTest
{
    public sealed class ControlPanelView : BaseUIView
    {
        #region Fields

        public Action OnIdle = delegate { };
        public Action OnPatrol = delegate { };
        public Action OnToBase = delegate { };

        [SerializeField] private Button _idleButton;
        [SerializeField] private Button _patrolButton;
        [SerializeField] private Button _toBaseButton;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _idleButton.onClick.AddListener(IdleButtonClick);
            _patrolButton.onClick.AddListener(PatrolButtonClick);
            _toBaseButton.onClick.AddListener(ToBaseButtonClick);
        }

        private void OnDisable()
        {
            _idleButton.onClick.RemoveListener(IdleButtonClick);
            _patrolButton.onClick.RemoveListener(PatrolButtonClick);
            _toBaseButton.onClick.RemoveListener(ToBaseButtonClick);
        }

        #endregion


        #region Methods

        private void IdleButtonClick()
        {
            OnIdle.Invoke();
        }

        private void PatrolButtonClick()
        {
            OnPatrol.Invoke();
        }

        private void ToBaseButtonClick()
        {
            OnToBase.Invoke();
        }

        #endregion
    }
}
