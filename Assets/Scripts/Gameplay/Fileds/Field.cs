using UnityEngine;
using System;

namespace Scripts.Gameplay.Fields
{
    public class Field : MonoBehaviour
    {
        [SerializeField]
        private bool _isCurrent;
        [SerializeField]
        private bool _isEnd = false;
        [SerializeField]
        private int _size;
        [SerializeField]
        private bool _wasStateChange = true;

        public int Row { get; private set; }
        public int Col { get; private set; }

        public bool IsCurrent
        {
            get
            {
                return _isCurrent;
            }
        }

        #region MonoBehavior Members
        private void Awake()
        {
            _size = Convert.ToInt32(transform.localScale.x);
            Update();
            Row = Convert.ToInt32(transform.position.z) / _size;
            Col = Convert.ToInt32(transform.position.x) / _size;
        }

        private void Update()
        {
            if (!_wasStateChange)
            {
                return;
            }

            ChangeColor();
            _wasStateChange = false;
        }
        #endregion

        public bool GetIsOk()
        {
            return _isCurrent == _isEnd;
        }

        public void MoveOn()
        {
            _wasStateChange = true;
            _isCurrent = true;
        }
        public void MoveFrom()
        {
            _wasStateChange = true;
            _isCurrent = false;
        }

        private void ChangeColor()
        {
            if (_isCurrent && _isEnd)
            {
                SwitchColor(Color.yellow);
            }
            else if (_isCurrent)
            {
                SwitchColor(Color.red);
            }
            else if (_isEnd)
            {
                SwitchColor(Color.green);
            }
            else
            {
                SwitchColor(Color.white);
            }
        }

        private void SwitchColor(Color color)
        {
            GetComponent<Renderer>().material.color = color;
        }
    }
}