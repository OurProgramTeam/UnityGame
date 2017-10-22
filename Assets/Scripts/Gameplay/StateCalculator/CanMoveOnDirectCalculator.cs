using Scripts.Gameplay.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Gameplay.StateCalculator
{
    public class CanMoveOnDirectCalculator
    {
        public bool CanMoveOnDirect(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            switch (orientation)
            {
                case Orientation.X:
                    return CalculateAllowedForX(fields, currentFields, direct);
                case Orientation.Y:
                    return CalculateAllowedForY(fields, currentFields, direct);
                case Orientation.Z:
                    return CalculateAllowedForZ(fields, currentFields, direct);
                default:
                    throw new Exception("CalculateAllowedDirects: current fields has no position");
            }
        }

        private bool CalculateAllowedForX(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var left = currentFields.First();
            var right = currentFields.Last();
            if (left.Col > right.Col)
            {
                left = currentFields.Last();
                right = currentFields.First();
            }

            if (direct == Direct.Left && fields.Any(f => f.Col == left.Col - 1 && f.Row == left.Row))
            {
                return true;
            }
            if (direct == Direct.Right && fields.Any(f => f.Col == right.Col + 1 && f.Row == right.Row))
            {
                return true;
            }
            if (direct == Direct.Up && fields.Any(f => f.Col == left.Col && f.Row == left.Row + 1)
                && fields.Any(f => f.Col == right.Col && f.Row == right.Row + 1))
            {
                return true;
            }
            if (direct == Direct.Down && fields.Any(f => f.Col == left.Col && f.Row == left.Row - 1)
                && fields.Any(f => f.Col == right.Col && f.Row == right.Row - 1))
            {
                return true;
            }

            return false;
        }

        private bool CalculateAllowedForY(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var field = currentFields.First();

            if (direct == Direct.Up && fields.Any(f => f.Row == field.Row + 1 && f.Col == field.Col)
                && fields.Any(f => f.Row == field.Row + 2 && f.Col == field.Col))
            {
                return true;
            }
            if (direct == Direct.Down && fields.Any(f => f.Row == field.Row - 1 && f.Col == field.Col)
                && fields.Any(f => f.Row == field.Row - 2 && f.Col == field.Col))
            {
                return true;
            }
            if (direct == Direct.Left && fields.Any(f => f.Row == field.Col - 1 && f.Col == field.Row)
                && fields.Any(f => f.Row == field.Col - 2 && f.Col == field.Row))
            {
                return true;
            }
            if (direct == Direct.Right && fields.Any(f => f.Row == field.Col + 1 && f.Col == field.Row)
                && fields.Any(f => f.Row == field.Col + 2 && f.Col == field.Row))
            {
                return true;
            }

            return false;
        }

        private bool CalculateAllowedForZ(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var bottom = currentFields.First();
            var top = currentFields.Last();
            if (bottom.Row > top.Row)
            {
                bottom = currentFields.Last();
                top = currentFields.First();
            }

            if (direct == Direct.Up && fields.Any(f => f.Col == top.Col && f.Row == top.Row + 1))
            {
                return true;
            }
            if (direct == Direct.Down && fields.Any(f => f.Col == bottom.Col && f.Row == bottom.Row - 1))
            {
                return true;
            }
            if (direct == Direct.Left && fields.Any(f => f.Row == top.Row && f.Col == top.Col - 1)
                && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col - 1))
            {
                return true;
            }
            if (direct == Direct.Right && fields.Any(f => f.Row == top.Row && f.Col == top.Col + 1)
                && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col + 1))
            {
                return true;
            }

            return false;
        }
    }
}