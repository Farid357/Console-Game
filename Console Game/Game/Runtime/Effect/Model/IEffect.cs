namespace ConsoleGame
{
    public interface IEffect
    {
        bool IsPlaying { get; }
        
        ITransform Transform { get; }
        
        void Play();

        void Stop();
    }
}