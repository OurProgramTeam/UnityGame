using UnityEngine;
using System;

namespace Scripts.Gameplay.Flip.Transformations
{
    public class TransfromComponents
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public TransfromComponents(Transform transfrom)
        {
            var srcPosition = transfrom.position;
            Position = new Vector3(
                Round(srcPosition.x),
                Round(srcPosition.y),
                Round(srcPosition.z)
            );

            var srcRotation = transfrom.rotation;
            Rotation = new Quaternion(
                Round(srcRotation.x),
                Round(srcRotation.y),
                Round(srcRotation.z),
                Round(srcRotation.w)
            );
        }

        private float Round(float number)
        {
            const int DigitsAfterDot = 2;

            return (float)Math.Round(number, DigitsAfterDot);
        }
    }
}