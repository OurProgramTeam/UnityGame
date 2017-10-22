using System;
using System.Collections.Generic;
using Scripts.Gameplay.Fields;
using System.Linq;

namespace Scripts.Gameplay.StateCalculator
{
    public class CurrentStateCalculator : ICurrentStateCalculator
    {
        private readonly CanMoveOnDirectCalculator _canMoveOnDirectCalculator;
        private readonly NextPositionCalculator _nextPositionCalculator;

        public CurrentStateCalculator()
        {
            _canMoveOnDirectCalculator = new CanMoveOnDirectCalculator();
            _nextPositionCalculator = new NextPositionCalculator();
        }

        public bool CalculateCanMoveOnDirect(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            return _canMoveOnDirectCalculator.CanMoveOnDirect(fields, currentFields, orientation, direct);
        }

        public List<Field> CalculateNextPosition(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            return _nextPositionCalculator.Calculate(fields, currentFields, orientation, direct);
        }

        public Orientation CalculateOrientaion(List<Field> currentFields)
        {
            if (currentFields.Count < 1 || currentFields.Count > 2)
            {
                throw new System.Exception(String.Format("current fields count is {0}", currentFields.Count));
            }

            if (currentFields.Count == 1)
            {
                return Orientation.Y;
            }
            if (currentFields[0].Row == currentFields[1].Row)
            {
                return Orientation.X;
            }
            if (currentFields[0].Col == currentFields[1].Col)
            {
                return Orientation.Z;
            }
            throw new Exception("Undefined current fields position");
        }
    }
}