using System;
using System.Collections.Generic;
using Scripts.Gameplay.Fields;
using System.Linq;

namespace Scripts.Gameplay.StateCalculator
{
    public class CurrentStateCalculator : ICurrentStateCalculator
    {
        private readonly ICanMoveOnDirectCalculator _canMoveOnDirectCalculator;
        private readonly INextPositionCalculator _nextPositionCalculator;
        private readonly IOrientaionCalculator _orientaionCalculator;

        public CurrentStateCalculator()
        {
            _canMoveOnDirectCalculator = new CanMoveOnDirectCalculator();
            _nextPositionCalculator = new NextPositionCalculator();
            _orientaionCalculator = new OrientaionCalculator();
        }

        public bool CalculateCanFlip(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            return _canMoveOnDirectCalculator.CanMoveOnDirect(fields, currentFields, orientation, direct);
        }

        public List<Field> CalculateTargetPosition(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            return _nextPositionCalculator.Calculate(fields, currentFields, orientation, direct);
        }

        public Orientation CalculateOrientaion(List<Field> currentFields)
        {
            return _orientaionCalculator.CalculateOrientaion(currentFields);
        }
    }
}