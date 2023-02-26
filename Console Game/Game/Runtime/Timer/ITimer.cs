namespace Console_Game
{
    public interface ITimer
    {
        bool FinishedCountdown { get; }
        
        bool IsActive { get; }

        void Play();
    }
}