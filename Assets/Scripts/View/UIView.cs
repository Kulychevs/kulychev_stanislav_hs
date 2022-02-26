using System;
using UnityEngine;
using UnityEngine.UI;


namespace HotSiberiansTest
{
    public sealed class UIView : MonoBehaviour
    {
        #region Fields

        public Action OnClose = delegate { };

        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private HPInfoView _hPInfoView;
        [SerializeField] private ControlPanelView _controlPanelView;
        [SerializeField] private Button _closeButton;

        #endregion


        #region Properties

        public ControlPanelView ControlPanelView => _controlPanelView;
        public MainMenuView MainMenuView => _mainMenuView;
        public HPInfoView HPInfoView => _hPInfoView;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(CloseButtonClick);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(CloseButtonClick);
        }

        #endregion


        #region Methods

        private void CloseButtonClick()
        {
            OnClose.Invoke();
        }

        #endregion
    }
}
