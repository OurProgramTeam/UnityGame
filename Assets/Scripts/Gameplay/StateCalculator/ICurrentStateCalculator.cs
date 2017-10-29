using Scripts.Gameplay.Fields;
using System.Collections.Generic;

namespace Scripts.Gameplay.StateCalculator
{
    public interface ICurrentStateCalculator
    {
        bool CalculateCanFlip(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct);

        List<Field> CalculateTargetPosition(
            List<Field> fields,
            List<Field> currentFields,
            Orientation orientation,
            Direct direct
        );

        Orientation CalculateOrientaion(List<Field> currentFields);
    }
}