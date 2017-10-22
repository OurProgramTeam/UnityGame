using UnityEngine;

namespace Scripts.Gameplay.Flip.FromDirectFactories
{
    public interface IFromDirectAbstractFactory
    {
        FlipResult FlipLeft(Transform transform);
        FlipResult FlipRight(Transform transform);
        FlipResult FlipUp(Transform transform);
        FlipResult FlipDown(Transform transform);
    }
}