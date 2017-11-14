using UnityEngine;
using System;
using Scripts.Utils;

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
                NumberUtils.RoundByDigitsCount(srcPosition.x, 2),
                NumberUtils.RoundByDigitsCount(srcPosition.y, 2),
                NumberUtils.RoundByDigitsCount(srcPosition.z, 2)
            );

            var srcRotation = transfrom.rotation.eulerAngles;
            Rotation = Quaternion.Euler(
                NumberUtils.RoundByStep(srcRotation.x, 90f),
                NumberUtils.RoundByStep(srcRotation.y, 90f),
                NumberUtils.RoundByStep(srcRotation.z, 90f)
            );
        }

        private float Round(float number)
        {
            const int DigitsAfterDot = 2;

            return (float)Math.Round(number, DigitsAfterDot);
        }
    }
}