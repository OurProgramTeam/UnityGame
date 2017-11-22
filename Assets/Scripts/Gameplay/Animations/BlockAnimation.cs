using UnityEngine;

namespace Scripts.Gameplay.Animations
{
    public class BlockAnimation : MonoBehaviour, IBlockAnimation
    {
        [SerializeField]
        private float _animationTime;

        private float ElapsedTime { get; set; }
        private bool _isOnAimation;

        private IAnimationObservable _animationObservable;

        #region IBlockAnimation members

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

        public bool IsStart
        {
            get
            {
                return IsOnAnimation;
            }
        }

        public bool IsEnd
        {
            get
            {
                return !IsOnAnimation;
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

            _animationObservable = FindObjectOfType<AnimationObservable>();
            _animationObservable.Register(this);
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
