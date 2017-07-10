using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Mechanics
{
    public class GameMap : MonoBehaviour
    {
        private Field[] _fields;
        private FlipCalculator _flipCalculator;
        private PositionCalculator _positionCalculator;
        private AllowedDirectsCalculator _allowedDirectsCalculator;

        public List<Field> Fields
        {
            get
            {
                return _fields.ToList();
            }
        }

        public List<Field> CurrentFields
        {
            get
            {
                return _fields.Where(f => f.IsCurrent).ToList();
            }
        }

        public Position CurrentPosition
        {
            get
            {
                return _positionCalculator.CalculatePosition(CurrentFields);
            }
        }

        public Dictionary<Direct, bool> AllowedDirects
        {
            get
            {
                return _allowedDirectsCalculator.CalculateAllowedDirects(Fields, CurrentFields, CurrentPosition);
            }
        }

        public void Flip(Direct direct)
        {
            var newCurrentPositions = _flipCalculator.CalculateCurrentFieldsAfterFlip(Fields, CurrentFields, CurrentPosition, direct);

            foreach (var field in CurrentFields)
            {
                field.MoveFrom();
            }
            foreach (var field in newCurrentPositions)
            {
                field.MoveOn();
            }
        }

        #region MonoBehavior Members
        private void Awake()
        {
            _fields = FindObjectsOfType<Field>();
            _flipCalculator = new FlipCalculator();
            _positionCalculator = new PositionCalculator();
            _allowedDirectsCalculator = new AllowedDirectsCalculator();
        }
        #endregion
    }
}
