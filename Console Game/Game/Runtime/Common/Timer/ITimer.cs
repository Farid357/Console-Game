namespace ConsoleGame
{
    public interface ITimer
    {
        float Time { get; }
        
        bool IsEnded { get; }
        
        bool IsActive { get; }

        void Play();

        void Stop();
        
        void ResetTime();
    }
}