using System;
using System.Collections.Generic;

namespace Scripts.Mechanics
{
    public class PositionCalculator
    {
        public Position CalculatePosition(List<Field> currentFields)
        {
            if (currentFields.Count < 1 || currentFields.Count > 2)
            {
                throw new System.Exception(String.Format("current fields count is {0}", currentFields.Count));
            }

            if (currentFields.Count == 1)
            {
                return Position.Y;
            }
            if (currentFields[0].Row == currentFields[1].Row)
            {
                return Position.X;
            }
            if (currentFields[0].Col == currentFields[1].Col)
            {
                return Position.Z;
            }
            throw new Exception("Undefined current fields position");
        }
    }
}