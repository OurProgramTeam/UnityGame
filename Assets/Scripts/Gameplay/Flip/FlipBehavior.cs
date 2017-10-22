using Scripts.Gameplay.Flip.FromDirectFactories;
using System;
using UnityEngine;

namespace Scripts.Gameplay.Flip
{
    public class FlipBehavior : IFlipBehavior
    {
        private const float DeltaAngle = 90f;

        private IFromDirectAbstractFactory FromDirectFactory { get; set; }

        public FlipBehavior(Orientation orientation)
        {
            SetCurrentFlipState(orientation);
        }

        #region IFlipBehavior members

        public Orientation Flip(Transform transform, Direct direct)
        {
            var flipResult = new FlipResult();
            var axis = new Vector3();

            switch (direct)
            {
                case Direct.Down:
                    axis = new Vector3(-1f, 0f, 0f);
                    flipResult = FromDirectFactory.FlipDown(transform);
                    break;
                case Direct.Up:
                    axis = new Vector3(1f, 0f, 0f);
                    flipResult = FromDirectFactory.FlipUp(transform);
                    break;
                case Direct.Left:
                    axis = new Vector3(0f, 0f, 1f);
                    flipResult = FromDirectFactory.FlipLeft(transform);
                    break;
                case Direct.Right:
                    axis = new Vector3(0f, 0f, -1f);
                    flipResult = FromDirectFactory.FlipRight(transform);
                    break;
                default:
                    throw new Exception("unknown direct");
            }

            SetCurrentFlipState(flipResult.Orientation);

            RotateAround(transform, flipResult.DeltaPoint, axis);

            return flipResult.Orientation;
        }

        #endregion

        private void SetCurrentFlipState( Orientation orientation )
        {
            switch (orientation)
            {
                case Orientation.X:
                    FromDirectFactory = new FromDirectXFactory();
                    break;
                case Orientation.Y:
                    FromDirectFactory = new FromDirectYFactory();
                    break;
                case Orientation.Z:
                    FromDirectFactory = new FromDirectZFactory();
                    break;
                default:
                    throw new Exception("unknown orientation");
            }
        }

        private void RotateAround(Transform transform, Vector3 deltaPoint, Vector3 axis)
        {
            transform.RotateAround(
                transform.position + deltaPoint,
                axis,
                DeltaAngle
            );
        }
    }
}