using Scripts.Gameplay.Fields;
using System.Collections.Generic;

namespace Scripts.Gameplay.StateCalculator
{
    public interface INextPositionCalculator
    {
        List<Field> Calculate(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct);
    }
}