using Scripts.Gameplay.Fields;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class GameMap : MonoBehaviour
    {
        public List<Field> Fields { get; set; }

        #region MonoBehaviour members

        private void Awake()
        {
            IFieldsService fieldsService = GetComponent<FieldsService>();
            Fields = fieldsService.GetFields();
        }

        #endregion

        public bool IsWin
        {
            get
            {
                return EndFields.All(f => f.IsOk) && CurrentFields.All(f => f.IsOk);
            }
        }

        public List<Field> CurrentFields
        {
            get
            {
                return Fields
                    .Where(f => f.IsCurrent)
                    .ToList();
            }
        }

        public List<Field> EndFields
        {
            get
            {
                return Fields
                    .Where(f => f.IsEnd)
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
