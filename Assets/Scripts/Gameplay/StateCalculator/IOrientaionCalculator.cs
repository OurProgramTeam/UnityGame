using Scripts.Gameplay.Fields;
using System.Collections.Generic;

namespace Scripts.Gameplay.StateCalculator
{
    public interface IOrientaionCalculator
    {
        Orientation CalculateOrientaion(List<Field> currentFields);
    }
}