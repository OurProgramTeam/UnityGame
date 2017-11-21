namespace Scripts.Gameplay.Animations
{
    public interface IAnimationObservable
    {
        bool IsAllEnd { get; }
        void Register(IAnimation animation);
    }
}