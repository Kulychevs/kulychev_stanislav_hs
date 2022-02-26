using System;
using UnityEngine;
using UnityEngine.UI;


namespace HotSiberiansTest
{
    public sealed class MainMenuView : BaseUIView
    {
        public Action OnStart = delegate { };

        [SerializeField] private Button _startButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartButtonClick);
        }

        private void StartButtonClick()
        {
            OnStart.Invoke();
        }
    }
}
