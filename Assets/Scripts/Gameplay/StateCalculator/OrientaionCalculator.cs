using Scripts.Gameplay.Fields;
using System;
using System.Collections.Generic;

namespace Scripts.Gameplay.StateCalculator
{
    public class OrientaionCalculator : IOrientaionCalculator
    {
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