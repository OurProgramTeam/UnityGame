using UnityEngine;

namespace Scripts.Gameplay.Flip.FromDirectFactories
{
    public class FromDirectYFactory : IFromDirectAbstractFactory
    {
        public FlipResult FlipDown(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.x / 2, -transform.localScale.z / 2),
                Orientation = Orientation.Z
            };
        }

        public FlipResult FlipLeft(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(-transform.localScale.y / 2, -transform.localScale.x / 2, 0f),
                Orientation = Orientation.X
            };
        }

        public FlipResult FlipRight(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(transform.localScale.y / 2, -transform.localScale.x / 2, 0f),
                Orientation = Orientation.X
            };
        }

        public FlipResult FlipUp(Transform transform)
        {
            return new FlipResult
            {
                DeltaPoint = new Vector3(0f, -transform.localScale.x / 2, transform.localScale.z / 2),
                Orientation = Orientation.Z
            };
        }
    }
}