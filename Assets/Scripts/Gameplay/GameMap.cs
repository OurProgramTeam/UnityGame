using Scripts.Gameplay.Fields;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Gameplay
{
    public class GameMap
    {
        public List<Field> Fields { get; set; }

        public List<Field> CurrentFields
        {
            get
            {
                return Fields
                    .Where(f => f.IsCurrent)
                    .ToList();
            }
        }

        public void Flip(List<Field> positionToMove)
        {
            foreach (var field in CurrentFields)
            {
                field.MoveFrom();
            }
            foreach (var field in positionToMove)
            {
                field.MoveOn();
            }
        }
    }
}
