namespace Console_Game.Loop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Play();

        void Stop();
    }
}