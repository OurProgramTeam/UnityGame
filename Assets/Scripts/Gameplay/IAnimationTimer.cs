namespace Scripts.Gameplay
{
    public interface IAnimationTimer
    {
        bool IsOnAnimation { get; }
        float ElapsedPart { get; }
        void StartAnimation();
    }
}
