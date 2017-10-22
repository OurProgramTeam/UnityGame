using Scripts.Gameplay.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Gameplay.StateCalculator
{
    public class NextPositionCalculator
    {
        public List<Field> Calculate(List<Field> fields, List<Field> currentFields, Orientation orientation, Direct direct)
        {
            List<Field> newCurrentFields = new List<Field>();
            switch (orientation)
            {
                case Orientation.X:
                    return GetCurrentAfterFlipFromX(fields, currentFields, direct);
                case Orientation.Y:
                    return GetCurrentAfterFlipFromY(fields, currentFields, direct);
                case Orientation.Z:
                    return GetCurrentAfterFlipFromZ(fields, currentFields, direct);
                default:
                    throw new Exception("undefined current position");
            }
        }

        private List<Field> GetCurrentAfterFlipFromX(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var left = currentFields.First(c => c.Col == currentFields.Min(cf => cf.Col));
            var right = currentFields.First(c => c.Col == currentFields.Max(cf => cf.Col));

            var newCurrentFields = new List<Field>();
            switch (direct)
            {
                case Direct.Up:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row + 1 ||
                        x.Col == right.Col && x.Row == right.Row + 1));
                    break;
                case Direct.Down:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row - 1 ||
                        x.Col == right.Col && x.Row == right.Row - 1));
                    break;
                case Direct.Left:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col - 1 && x.Row == left.Row));
                    break;
                case Direct.Right:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == right.Col + 1 && x.Row == right.Row));
                    break;
            }

            return newCurrentFields;
        }

        private List<Field> GetCurrentAfterFlipFromZ(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var bottom = currentFields.First(c => c.Row == currentFields.Min(cf => cf.Row));
            var top = currentFields.First(c => c.Row == currentFields.Max(cf => cf.Row));

            var newCurrentFields = new List<Field>();
            switch (direct)
            {
                case Direct.Up:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col && x.Row == top.Row + 1));
                    break;
                case Direct.Down:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == bottom.Col && x.Row == bottom.Row - 1));
                    break;
                case Direct.Left:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col - 1 && x.Row == top.Row ||
                        x.Col == bottom.Col - 1 && x.Row == bottom.Row));
                    break;
                case Direct.Right:
                    newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col + 1 && x.Row == top.Row ||
                        x.Col == bottom.Col + 1 && x.Row == bottom.Row));
                    break;
            }
            return newCurrentFields;
        }

        private List<Field> GetCurrentAfterFlipFromY(List<Field> fields, List<Field> currentFields, Direct direct)
        {
            var current = currentFields.First();

            var newCurrentFields = new List<Field>();
            switch (direct)
            {
                case Direct.Up:
                    newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row + 1 && x.Col == current.Col ||
                        x.Row == current.Row + 2 && x.Col == current.Col));
                    break;
                case Direct.Down:
                    newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row - 1 && x.Col == current.Col ||
                        x.Row == current.Row - 2 && x.Col == current.Col));
                    break;
                case Direct.Left:
                    newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col - 1 ||
                        x.Row == current.Row && x.Col == current.Col - 2));
                    break;
                case Direct.Right:
                    newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col + 1 ||
                        x.Row == current.Row && x.Col == current.Col + 2));
                    break;
            }
            return newCurrentFields;
        }
    }
}