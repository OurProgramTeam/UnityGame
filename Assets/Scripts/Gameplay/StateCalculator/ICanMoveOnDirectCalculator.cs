using Scripts.Gameplay.Fields;
using System.Collections.Generic;

namespace Scripts.Gameplay.StateCalculator
{
    public interface ICanMoveOnDirectCalculator
    {
        bool CanMoveOnDirect(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct);
    }
}