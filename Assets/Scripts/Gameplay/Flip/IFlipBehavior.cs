using UnityEngine;

namespace Scripts.Gameplay.Flip
{
    public interface IFlipBehavior
    {
        void Init(Orientation blockOrientation);
        Orientation Flip(Direct direct);
    }
}