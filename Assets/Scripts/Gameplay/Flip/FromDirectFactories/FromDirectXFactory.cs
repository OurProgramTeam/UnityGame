using UnityEngine;

namespace Scripts.Gameplay.Flip.FromDirectFactories
{
    public class FromDirectXFactory : IFromDirectAbstractFactory
    {
        #region IFlipState members

        public FlipResult FlipDown(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.y / 2, -transform.localScale.z / 2),
                Orientation = Orientation.X
            };
        }

        public FlipResult FlipLeft(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(-transform.localScale.x / 2, -transform.localScale.y / 2, 0f),
                Orientation = Orientation.Y
            };
        }

        public FlipResult FlipRight(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(transform.localScale.x / 2, -transform.localScale.y / 2, 0f),
                Orientation = Orientation.Y
            };
        }

        public FlipResult FlipUp(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.y / 2, transform.localScale.z / 2),
                Orientation = Orientation.X
            };
        }

        #endregion
    }
}