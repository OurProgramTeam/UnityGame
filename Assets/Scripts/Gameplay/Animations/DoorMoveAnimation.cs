using UnityEngine;

namespace Scripts.Gameplay.Animations
{
    public class DoorMoveAnimation : MonoBehaviour, IAnimation
    {
        [SerializeField]
        private float _animationTime;

        [SerializeField]
        private float _yEndPosition;

        private float _elapsedTime;
        private float _speed;

        private IAnimationObservable _animationObservable;
        private GameMap _gameMap;

        #region IAnimation members

        public bool IsEnd { get; private set; }

        public bool IsStart { get; private set; }

        public bool IsOnAnimation
        {
            get
            {
                return IsStart && !IsEnd;
            }
        }

        public void StartAnimation()
        {
            _elapsedTime = 0f;
            IsStart = true;
            IsEnd = false;
        }

        #endregion

        #region MonoBehaviour members

        // Use this for initialization
        void Start()
        {
            IsStart = false;
            IsEnd = false;
            _elapsedTime = 0f;
            _speed = (_yEndPosition - transform.position.y) / _animationTime;

            _animationObservable = FindObjectOfType<AnimationObservable>();
            _animationObservable.Register(this);

            _gameMap = FindObjectOfType<GameMap>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsStart && _gameMap.IsWin)
            {
                StartAnimation();
            }
            if (IsOnAnimation)
            {
                Move();
            }
        }

        #endregion

        private void Move()
        {
            if (_elapsedTime >= _animationTime)
            {
                IsEnd = true;
                return;
            }

            var deltaTime = Time.deltaTime;
            var deltaY = deltaTime * _speed;

            _elapsedTime += deltaTime;
            transform.Translate(0f, deltaY, 0f);
        }
    }
}
