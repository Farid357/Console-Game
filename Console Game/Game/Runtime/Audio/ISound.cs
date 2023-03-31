namespace ConsoleGame.Audio
{
    public interface ISound
    {
        bool IsPlaying { get; }
        
        void Play();

        void Stop();
    }
}