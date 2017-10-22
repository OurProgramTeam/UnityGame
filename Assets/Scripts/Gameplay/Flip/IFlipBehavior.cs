using UnityEngine;

namespace Scripts.Gameplay.Flip
{
    public interface IFlipBehavior
    {
        Orientation Flip(Transform transform, Direct direct);
    }
}