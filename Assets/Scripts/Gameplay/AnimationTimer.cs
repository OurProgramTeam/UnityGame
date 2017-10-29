using System;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class AnimationTimer : MonoBehaviour, IAnimationTimer
    {
        [SerializeField]
        private float _animationTime;

        private float ElapsedTime { get; set; }
        private bool _isOnAimation;

        #region IAnimationTimer members

        public bool IsOnAnimation
        {
            get
            {
                return _isOnAimation;
            }
        }

        public float ElapsedPart
        {
            get
            {
                if ( !IsOnAnimation)
                {
                    return 0f;
                }
                return ElapsedTime / _animationTime;
            }
        }

        public void StartAnimation()
        {
            _isOnAimation = true;
        }

        #endregion

        #region MonoBehaviour members

        private void Start()
        {
            _isOnAimation = false;
            ElapsedTime = 0f;
        }

        private void Update()
        {
            if (!_isOnAimation)
            {
                return;
            }

            if ( ElapsedTime >= _animationTime)
            {
                _isOnAimation = false;
                ElapsedTime = 0f;
            }
            else
            {
                ElapsedTime += Time.deltaTime;
            }
        }

        #endregion
    }
}
