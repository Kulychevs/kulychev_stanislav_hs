using System;
using UnityEngine;


namespace HotSiberiansTest
{
    public sealed class PlayerView : MonoBehaviour
    {
        #region Fields

        public Action OnClick = delegate { };

        private const string IS_IDLE = "isIdle";

        private Animator _animator;
        private Collider2D _collired;
        private SpriteRenderer _renderer;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collired = GetComponent<CircleCollider2D>();
            _renderer = GetComponent<SpriteRenderer>();
            SetActive(false);
        }

        private void OnMouseDown()
        {
            OnClick();
        }

        #endregion


        #region Methods

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void PlayIdleAnimation(bool isIdle)
        {
            _animator.SetBool(IS_IDLE, isIdle);
        }

        public void SetActive(bool isActive)
        {
            _renderer.enabled = isActive;
            _collired.enabled = isActive;
        }

        #endregion
    }
}
