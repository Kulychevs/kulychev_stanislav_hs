using System;
using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class UIController
    {
        #region Fields

        public Action OnStartGame = delegate { };
        public Action OnClose = delegate { };
        public Action OnIdle = delegate { };
        public Action OnPatrol = delegate { };
        public Action OnToBase = delegate { };

        private readonly UIView _uIView;

        #endregion


        #region ClassLifeCycles

        public UIController()
        {
            _uIView = GameObject.FindObjectOfType<UIView>();
            _uIView.MainMenuView.OnStart += StartButtonClick;
            _uIView.OnClose += CloseButtonClick;
            _uIView.ControlPanelView.OnIdle += IdleButtonClick;
            _uIView.ControlPanelView.OnPatrol += PatrolButtonClick;
            _uIView.ControlPanelView.OnToBase += ToBaseButtonClick;
            ActivateMainMenu(true);
        }

        #endregion


        #region Methods

        public void SetNormalizedHP(float hp)
        {
            _uIView.HPInfoView.SetNormalizedHP(hp);
        }

        private void StartButtonClick()
        {
            ActivateMainMenu(false);
            OnStartGame.Invoke();
        }

        private void CloseButtonClick()
        {
            ActivateMainMenu(true);
            OnClose.Invoke();
        }

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

        private void ActivateMainMenu(bool isActive)
        {
            _uIView.MainMenuView.SetActive(isActive);
        }

        #endregion
    }
}
