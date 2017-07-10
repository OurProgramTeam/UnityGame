using System;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Mechanics
{
    public class AllowedDirectsCalculator
    {
        public Dictionary<Direct, bool> CalculateAllowedDirects(List<Field> fields, List<Field> currentFields, Position position)
        {
            if (position == Position.X)
            {
                return CalculateAllowedForX(fields, currentFields);
            }
            if (position == Position.Y)
            {
                return CalculateAllowedForY(fields, currentFields);
            }
            if (position == Position.Z)
            {
                return CalculateAllowedForZ(fields, currentFields);
            }
            throw new Exception("CalculateAllowedDirects: current fields has no position");
        }

        private Dictionary<Direct, bool> CalculateAllowedForX(List<Field> fields, List<Field> currentFields)
        {
            var allowedDirects = GetAllFalse();
            var left = currentFields.First();
            var right = currentFields.Last();
            if (left.Col > right.Col)
            {
                left = currentFields.Last();
                right = currentFields.First();
            }

            if (fields.Any(f => f.Col == left.Col - 1 && f.Row == left.Row))
            {
                allowedDirects[Direct.Left] = true;
            }
            if (fields.Any(f => f.Col == right.Col + 1 && f.Row == right.Row))
            {
                allowedDirects[Direct.Right] = true;
            }
            if (fields.Any(f => f.Col == left.Col && f.Row == left.Row + 1)
                && fields.Any(f => f.Col == right.Col && f.Row == right.Row + 1))
            {
                allowedDirects[Direct.Up] = true;
            }
            if (fields.Any(f => f.Col == left.Col && f.Row == left.Row - 1)
                && fields.Any(f => f.Col == right.Col && f.Row == right.Row - 1))
            {
                allowedDirects[Direct.Down] = true;
            }

            return allowedDirects;
        }

        private Dictionary<Direct, bool> CalculateAllowedForY(List<Field> fields, List<Field> currentFields)
        {
            var allowedDirects = GetAllFalse();
            var field = currentFields.First();

            if (fields.Any(f => f.Row == field.Row + 1 && f.Col == field.Col)
                && fields.Any(f => f.Row == field.Row + 2 && f.Col == field.Col))
            {
                allowedDirects[Direct.Up] = true;
            }
            if (fields.Any(f => f.Row == field.Row - 1 && f.Col == field.Col)
                && fields.Any(f => f.Row == field.Row - 2 && f.Col == field.Col))
            {
                allowedDirects[Direct.Down] = true;
            }
            if (fields.Any(f => f.Row == field.Col - 1 && f.Col == field.Row)
                && fields.Any(f => f.Row == field.Col - 2 && f.Col == field.Row))
            {
                allowedDirects[Direct.Left] = true;
            }
            if (fields.Any(f => f.Row == field.Col + 1 && f.Col == field.Row)
                && fields.Any(f => f.Row == field.Col + 2 && f.Col == field.Row))
            {
                allowedDirects[Direct.Right] = true;
            }

            return allowedDirects;
        }

        private Dictionary<Direct, bool> CalculateAllowedForZ(List<Field> fields, List<Field> currentFields)
        {
            var allowedDirects = GetAllFalse();
            var bottom = currentFields.First();
            var top = currentFields.Last();
            if (bottom.Row > top.Row)
            {
                bottom = currentFields.Last();
                top = currentFields.First();
            }

            if (fields.Any(f => f.Col == top.Col && f.Row == top.Row + 1))
            {
                allowedDirects[Direct.Up] = true;
            }
            if (fields.Any(f => f.Col == bottom.Col && f.Row == bottom.Row - 1))
            {
                allowedDirects[Direct.Down] = true;
            }
            if (fields.Any(f => f.Row == top.Row && f.Col == top.Col - 1)
                && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col - 1))
            {
                allowedDirects[Direct.Left] = true;
            }
            if (fields.Any(f => f.Row == top.Row && f.Col == top.Col + 1)
                && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col + 1))
            {
                allowedDirects[Direct.Right] = true;
            }

            return allowedDirects;
        }

        private Dictionary<Direct, bool> GetAllFalse()
        {
            var result = new Dictionary<Direct, bool>
            {
                { Direct.Left, false },
                { Direct.Right, false },
                { Direct.Up, false },
                { Direct.Down, false }
            };
            return result;
        }
    }
}