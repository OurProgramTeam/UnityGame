using UnityEngine;

namespace Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private Position _currentPosition;
        private FlipBehavior _flipBehavior;

        public Position CurrentPosition
        {
            set
            {
                _currentPosition = value;
            }
        }

        #region MonoBehavior Members
        private void Start()
        {
            _flipBehavior = new FlipBehavior();
        }
        #endregion

        public void FlipRight()
        {
            _flipBehavior.FlipRight(transform, ref _currentPosition);
        }

        public void FlipLeft()
        {
            _flipBehavior.FlipLeft(transform, ref _currentPosition);
        }

        public void FlipDown()
        {
            _flipBehavior.FlipDown(transform, ref _currentPosition);
        }

        public void FlipUp()
        {
            _flipBehavior.FlipUp(transform, ref _currentPosition);
        }
    }
}
