using UnityEngine;

namespace Scripts.Gameplay.Flip.Transformations
{
    public class Transformation
    {
        public TransfromComponents Source { get; set; }
        public TransfromComponents Target { get; set; }

        public Vector3 DeltaPoint;
        public Vector3 Axis;
    }
}