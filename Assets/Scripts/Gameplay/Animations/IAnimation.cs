namespace Scripts.Gameplay.Animations
{
    public interface IAnimation
    {
        bool IsStart { get; }
        bool IsEnd { get; }
        bool IsOnAnimation { get; }
        void StartAnimation();
    }
}