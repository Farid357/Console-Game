namespace Console_Game
{
    public interface ITimer
    {
        bool FinishedCountdown { get; }

        void Play();
    }
}