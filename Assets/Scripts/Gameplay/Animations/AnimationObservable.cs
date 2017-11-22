using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Gameplay.Animations
{
    public class AnimationObservable : MonoBehaviour, IAnimationObservable
    {
        private List<IAnimation> _observers = new List<IAnimation>();

        #region MonoBehaviour members
        #endregion

        #region IAnimationObservable members

        public bool IsAllEnd
        {
            get
            {
                return _observers.All(a => a.IsEnd);
            }
        }

        public void Register(IAnimation animation)
        {
            var found = _observers.FirstOrDefault(a => ReferenceEquals(a, animation));
            
            if (found != null)
            {
                return;
            }

            _observers.Add(animation);
        }

        #endregion
    }
}