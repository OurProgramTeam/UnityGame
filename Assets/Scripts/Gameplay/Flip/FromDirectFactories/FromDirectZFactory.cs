using UnityEngine;

namespace Scripts.Gameplay.Flip.FromDirectFactories
{
    public class FromDirectZFactory : IFromDirectAbstractFactory
    {
        #region IFlipState members

        public FlipResult FlipDown(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.y / 2, -transform.localScale.x / 2),
                Orientation = Orientation.Y
            };
        }

        public FlipResult FlipLeft(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(-transform.localScale.y / 2, -transform.localScale.y / 2, 0f),
                Orientation = Orientation.Z
            };
        }

        public FlipResult FlipRight(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(transform.localScale.y / 2, -transform.localScale.y / 2, 0f),
                Orientation = Orientation.Z
            };
        }

        public FlipResult FlipUp(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.y / 2, transform.localScale.x / 2),
                Orientation = Orientation.Y
            };
        }

        #endregion
    }
}