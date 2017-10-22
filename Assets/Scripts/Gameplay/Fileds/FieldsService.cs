using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Gameplay.Fields
{
    public class FieldsService : MonoBehaviour, IFieldsService
    {
        public List<Field> GetFields()
        {
            var fields = FindObjectsOfType<Field>().ToList();

            return fields;
        }
    }
}