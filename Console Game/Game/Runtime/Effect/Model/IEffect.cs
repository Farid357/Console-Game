namespace ConsoleGame
{
    public interface IEffect
    {
        bool IsPlaying { get; }
        
        void Play();

        void Stop();
    }
}